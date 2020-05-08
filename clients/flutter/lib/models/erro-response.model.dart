class ErroResponse {
  List<String> errors;

  ErroResponse({this.errors});

  ErroResponse.fromJson(Map<String, dynamic> json) {
    errors = json['errors'].cast<String>();
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['errors'] = this.errors;
    return data;
  }
}
