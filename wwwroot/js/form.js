var email = document.querySelector("#email");
var messemail = document.querySelector(".message__email");
// phone
var number = document.querySelector("#phone");
var messnumber = document.querySelector(".message__number");

// sign up
var signup = document.querySelector("#signup");
var messsignup = document.querySelector(".message__signup");

// password
var pass = document.querySelector("#password");
var messepass = document.querySelector(".message__password");

var btn = document.querySelector(".btn--signup");

// block--suscess
var sus = document.querySelector(".block__suscess");
// btn--close
var close = document.querySelector(".close--btn");

var mess = document.getElementById(".message");
btn.addEventListener("click", function () {
  // email
  if (
    ValidateEmail(email.value) == true &&
    Validatenumber(number.value) == true &&
    Validatesignup(signup.value) == true &&
    Validatespassword(pass.value) == true
  ) {
    sus.style.display = "flex";
    console.log("đúng");
    messemail.innerText = "";
    messsignup.innerText = "";
    messnumber.innerText = "";
    messepass.innerText = "";
  }
  console.log("Đã nhấn");
  if (Validatespassword(pass.value) == false) {
    messepass.innerText =
      "Password chua dat yeu cau toi thieu 8 ky tu va 1 chu so";
  }
  if (ValidateEmail(email.value) == false)
    messemail.innerText = "Kiem tra lai email";
  if (Validatesignup(signup.value) == false)
    messsignup.innerText = "Tai khoan it nhat 5 ky tu";
  if (Validatenumber(number.value) == false)
    messnumber.innerText = "chi duoc nhap so trong truong nay";
});
function ValidateEmail(input) {
  var validRegex =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

  if (input.match(validRegex)) {
    return true;
  } else {
    return false;
  }
}
// số dien thoai

function Validatenumber(input) {
  var validRegex = /^[0-9]*$/;

  if (input.match(validRegex)) {
    return true;
  } else {
    return false;
  }
}
//
function Validatesignup(input) {
  var validRegex = /^[a-zA-Z0-9]{5,}$/;

  if (input.match(validRegex)) {
    return true;
  } else {
    return false;
  }
}
// mat khau
// 8 ky tu 1 so 1 chu cai
function Validatespassword(input) {
  var validRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
  if (input.match(validRegex)) {
    return true;
  } else {
    return false;
  }
}
// dong

close.addEventListener("click", function () {
  sus.style.display = "none";
});
