import 'package:flutter/material.dart';

import 'game.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Align(
            alignment: AlignmentGeometry.center,
            child: Text("birdle"),
          ),
        ),
        body: Center(
          child: GamePage()
        ),
      ),
    );
  }
}

class Tile extends StatelessWidget {
  const Tile(this.letter, this.hitType, {super.key});

  final String letter;
  final HitType hitType;

  @override
  Widget build(BuildContext context) {
    return AnimatedContainer(
      duration: Duration(milliseconds: 500),
      curve: Curves.easeInOutQuad,
      width: 64,
      height: 64,
      decoration: BoxDecoration(
        border: Border.all(color: Colors.black, width: 2.0),
        color: switch(hitType){
          HitType.hit => Colors.green,
          HitType.partial => Colors.yellow,
          HitType.miss => Colors.grey,
          _ => Colors.white
        }
      ),
      child: Center(
        child: Text(
          letter.toUpperCase(),
          style: Theme.of(context).textTheme.titleLarge,
        ),
      ),
    );
  }
}

class GamePage extends StatefulWidget {
  GamePage({super.key});

  @override
  State<GamePage> createState() => _GamePageState();
}

class GuessInput extends StatefulWidget {
  GuessInput({super.key, required this.onSubmitGuess});

  final void Function(String) onSubmitGuess;
  
  @override
  State<GuessInput> createState() => _GuessInputState();
}

class _GuessInputState extends State<GuessInput>{
  final TextEditingController _textEditingController = TextEditingController();
  final FocusNode _focusNode = FocusNode();

  @override
  void dispose() {
    _textEditingController.dispose();
    _focusNode.dispose();
    super.dispose();
  }

  void onGuess()
  {
    widget.onSubmitGuess(_textEditingController.text.trim());
    _textEditingController.clear();
    _focusNode.requestFocus();
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: TextField(
              autofocus: true,
              focusNode: _focusNode,
              controller: _textEditingController,
              onSubmitted: (_) {
                onGuess();
              },
              maxLength: 5,
              decoration: InputDecoration(
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.all(Radius.circular(35)),
                ),
              ),
            ),
          ),
        ),
        IconButton(
          // This is not JS. It does not take ()=>{} lambda style
          onPressed: onGuess,
          icon: const Icon(Icons.arrow_circle_up),
          padding: EdgeInsets.zero)
      ],
    );
  }
}

class _GamePageState extends State<GamePage>{
  final Game _game = Game();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        spacing: 5.0,
        children: [..._game.guesses.map((guess) => Row(
          spacing: 5.0,
          mainAxisSize: MainAxisSize.min,
          children: [...guess.map((record)=>Tile(record.char, record.type))],
        )),GuessInput(onSubmitGuess: (String guess)=>{
          setState(() {
            _game.guess(guess);
          })
        },)],
      )
    );
  }
}
