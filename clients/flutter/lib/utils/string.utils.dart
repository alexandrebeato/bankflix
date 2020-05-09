// Anteriormente era um extension method
// mas a atualização de 08/05/2020 quebrou o método.
// Se possível refatora-lo como extension method.
class StringUtils {
  static bool isNullOrEmpty(String value) => value == null || value.isEmpty;
}
