import 'package:flutter/material.dart';

const brightness = Brightness.light;
const primaryColor = const Color(0xFF993399);
const accentColor = const Color(0xFFE0C2E0);

ThemeData lightTheme() {
  return ThemeData(
      brightness: brightness,
      primaryColor: primaryColor,
      accentColor: accentColor);
}
