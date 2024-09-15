import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:http/http.dart';

class LoginPage extends StatelessWidget {
  final Function(String)? onLogin;
  final TextEditingController _userController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  Future<String> login() async {
    String _apiUrl = dotenv.env['API_URL']!;
    String _user = _userController.text;
    String _password = _passwordController.text;

    try {
      // Construa a requisição com JSON corretamente
      Response response = await post(
        Uri.parse('$_apiUrl/account/login'),
        headers: <String, String>{
          'Content-Type': 'application/json',
        },
        body: jsonEncode(<String, String>{
          'username': _user,
          'password': _password,
        }),
      );

      if (response.statusCode == 200) {
        return jsonDecode(response.body)['token'];
      } else {
        print('Erro: ${response.statusCode} - ${response.body}');
        return '';
      }
    } catch (e) {
      print('Erro: $e');
      return '';
    }
  }

  LoginPage({super.key, this.onLogin});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: const EdgeInsets.symmetric(vertical: 16.0, horizontal: 50.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const Icon(Icons.calendar_month, size: 125),

              const SizedBox(height: 16.0),

              TextField(
                controller: _userController,
                decoration: const InputDecoration(
                  labelText: 'Usuário',
                ),
              ),

              const SizedBox(height: 16.0),

              TextField(
                controller: _passwordController,
                decoration: const InputDecoration(
                  labelText: 'Senha',
                ),
                obscureText: true,
              ),

              const SizedBox(height: 16.0),

              ElevatedButton(
                onPressed: () async {
                  String token = await login();
                  if (token.isNotEmpty && onLogin != null) {
                    onLogin!(token) ;
                  } else {
                    // Mostrar mensagem de erro
                    print('Erro ao fazer login.');
                  }
                },
                child: const Text('Entrar'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
