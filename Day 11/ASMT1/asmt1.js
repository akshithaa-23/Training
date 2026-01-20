//Task 1– Select by ID
let tit=document.getElementById('pageTitle');
tit.innerText='Customer Insurance Overview';

//Task 2– Select by Tag Name 

let cust=document.getElementsByTagName('li');
for (let i=0;i<cust.length;i++){
cust[i].style.border='2px solid';
cust[i].style.margin='2px';
cust[i].style.padding='2px';
}
let c=cust.length;
console.log('Total number of customers are ' +c);

//Task 3– Select by Class Name
let p=document.getElementsByClassName('policy');
for(let i=0;i<p.length;i++){
p[i].style.color='blue';
p[i].classList.add('highlight');
}

//Task 4– Select using CSS Selectors 
let cust1=document.querySelector('.customer');
console.log(cust1.innerText);
cust1.style.backgroundColor='Yellow';
console.log('All Customers');
let custall=document.querySelectorAll('.customer');
for(let i=0;i<custall.length;i++){
console.log(custall[i].innerText);
}
let custlen=custall.length;
custall[custlen-1].classList.add('active');


//Task 5– HTML Object Collec ons 
let nof=document.querySelectorAll('form')
console.log('No of forms '+nof.length);

let noi=document.querySelectorAll('img');
console.log('No of images '+ noi.length);

let textlink=document.getElementsByTagName('a');
for(let i=0;i<textlink.length;i++){
textlink[i].innerText='More Info';
}

//Task 6– Add a new customer dynamically and observe:

let el=document.createElement('li')
el.className='customer';
el.textContent="Kalyan – Health";
document.getElementById('customerList').append(el);

//Task 7 – Attribute-Based Selec on 

let at=document.querySelectorAll('input[type="text"]');
for(let i=0;i<at.length;i++){
     at[i].style.backgroundColor='yellow';
     at[i].setAttribute('placeholder','Enter Full Name')
    }

//Task 8 – Mul ple Class Selec on 

let m=document.querySelectorAll('.customer.active');
m.forEach((i)=>{
    i.style.color='darkgreen';
    i.textContent+=' (Priority Customer)';
});

//TASK 9
let des = document.querySelectorAll("#customerList li");
let deschild = document.querySelectorAll("#customerList > li");
console.log(des.length);
console.log(deschild.length);
//Task 10 – Even / Odd Selec on (CSS Pseudo Selectors) 

let evenodd = document.querySelectorAll("#customerList li");

evenodd.forEach((li, index) => {
  if ((index+1) % 2 === 0) {
    // item.classList.add("highlight");
    li.style.backgroundColor = "#e5e7eb";
  } else {
    // item.classList.add("highlight");
    li.style.backgroundColor = "#dbeafe";
  }
});

//Task 11 – Form Elements Collec on 

let form = document.forms["enquiryForm"];

for (let el of form.elements) {
    if (el.name) {
        console.log("Input field:", el.name);
    }
}
form.querySelector("button").disabled = true;

//Task 12 – NodeList vs HTMLCollec on
let policyHTMLCollection = document.getElementsByClassName("policy");
let policyNodeList = document.querySelectorAll(".policy");

let newPolicy = document.createElement("p");
newPolicy.className = "policy";
newPolicy.textContent = "Travel Insurance";
document.body.appendChild==(newPolicy);

console.log("HTMLCollection updated:", policyHTMLCollection.length);
console.log("NodeList static:", policyNodeList.length);


//Task 13
let customers = document.querySelectorAll(".customer");
customers.forEach((cust) => {
  let text = cust.textContent;
  if (text.includes("Life")) {
    cust.classList.add("highlight");
    cust.style.backgroundColor = "yellow";
  }
  if (text.includes("Vehicle")) {
    cust.style.display = "none";
  }
});

//Task 14
let customerItems = document.querySelectorAll("ul li");

customerItems.forEach((li) => {
  li.addEventListener("click", function () {
    let ul = li.closest("ul");
    ul.style.border = "3px solid blue";
  });
});

//Task 15 – Complex Selector Challenge
let policyExceptFirst = document.querySelectorAll("p.policy:not(:first-child)");

policyExceptFirst.forEach(p => {
    p.style.fontStyle = "italic";
    p.textContent = "✔ " + p.textContent;
});
