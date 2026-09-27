import 'dart:io';
import 'package:http/http.dart' as http; 
import 'package:command_runner/command_runner.dart';

import 'package:cli/cli.dart';
import 'package:command_runner/command_runner.dart';


const version = '0.0.1';

void main(List<String> arguments) {
  final errorLogger = initFileLogger('errors');
  final app =
      CommandRunner(
          onOutput: (String output) async {
            await write(output);
          },
          onError: (Object error) {
            if (error is Error) {
              errorLogger.severe(
                '[Error] ${error.toString()}\n${error.stackTrace}',
              );
              throw error;
            }
            if (error is Exception) {
              errorLogger.warning(error);
              print(error);
            }
          },
        )
        ..addCommand(HelpCommand())
        ..addCommand(SearchCommand(logger: errorLogger))
        ..addCommand(GetArticleCommand(logger: errorLogger));

  app.run(arguments);
}

void searchWikipedia(List<String>? arguments) async {
  final String articleTitle;

  // If the user didn't pass in arguments, request an article title.
  if (arguments == null || arguments.isEmpty) {
    print('Please provide an article title.');
    // Await input and provide a default empty string if the input is null.
    final inputStdin = stdin.readLineSync() ?? '';
    if (inputStdin == null || inputStdin.isEmpty) {
      print('No article title provided. Exiting.');
      return; // Exit the function if there's no valid input.
    }
    articleTitle = inputStdin;
  } else {
    // Otherwise, join the arguments into a single string.
    articleTitle = arguments.join(' ');
  }

  print('Looking up articles about "$articleTitle". Please wait.');

  var articleContent = await getWikipediaArticle(articleTitle);
  print(articleContent);
}

void printUsage() {
  print(
    "The following commands are valid: 'help', 'version', 'search <ARTICLE-TITLE>'"
  );
}

//Future<Type> is like 'Promise<Type>' then.
Future<String> getWikipediaArticle(String articleTitle) async {
  final url = Uri.https(
    'en.wikipedia.org', // Wikipedia API domain
    '/api/rest_v1/page/summary/$articleTitle', // API path for article summary
  );

  final httpResponse = await http.get(url);

  if(httpResponse.statusCode == 200)
  {
    return httpResponse.body;
  }

  return "Error: Cannot fetch $articleTitle. Status Code ${httpResponse.statusCode}";
}