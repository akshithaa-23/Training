let customers = [];

const enquiryForm = document.getElementById("enquiryForm");
const customerNameInput = document.getElementById("customerName");
const ageInput = document.getElementById("age");
const emailInput = document.getElementById("email");
const policyTypeInput = document.getElementById("policyType");
const coverageInput = document.getElementById("coverage");

const nameError = document.getElementById("nameError");
const ageError = document.getElementById("ageError");
const emailError = document.getElementById("emailError");
const policyError = document.getElementById("policyError");
const coverageError = document.getElementById("coverageError");

const filterPolicy = document.getElementById("filterPolicy");
const searchName = document.getElementById("searchName");

const customerTable = document.getElementById("customerTable");
const totalCustomersEl = document.getElementById("totalCustomers");
const totalPremiumEl = document.getElementById("totalPremium");

document.querySelectorAll("button.btn-hover").forEach((btn) => {
  btn.addEventListener("click", function (e) {
    if (e.target.textContent.trim() === "Enroll") {
      const card = e.target.closest(".border");
      const planName = card ? card.querySelector("h3").textContent : "";
      
      if (planName.includes("Health")) {
        policyTypeInput.value = "Health Insurance";
      } else if (planName.includes("Life")) {
        policyTypeInput.value = "Life Insurance";
      } else if (planName.includes("Vehicle")) {
        policyTypeInput.value = "Vehicle Insurance";
      }
      
      customerNameInput.focus();
    }
  });
});

function clearErrors() {
  nameError.textContent = "";
  ageError.textContent = "";
  emailError.textContent = "";
  policyError.textContent = "";
  coverageError.textContent = "";
}

function validateForm() {
  clearErrors();
  let isValid = true;

  const name = customerNameInput.value.trim();
  const age = Number(ageInput.value);
  const email = emailInput.value.trim();
  const policyType = policyTypeInput.value;
  const coverage = Number(coverageInput.value);

  if (name === "") {
    nameError.textContent = "Name is required";
    isValid = false;
  }

  if (!ageInput.value.trim()) {
    ageError.textContent = "Age is required";
    isValid = false;
  } else if (age < 1 || age > 100) {
    ageError.textContent = "Enter valid age (1 to 100)";
    isValid = false;
  }

  const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (email === "") {
    emailError.textContent = "Email is required";
    isValid = false;
  } else if (!emailPattern.test(email)) {
    emailError.textContent = "Enter valid email";
    isValid = false;
  }

  if (policyType === "") {
    policyError.textContent = "Select policy type";
    isValid = false;
  }

  if (!coverage || coverage < 100000) {
    coverageError.textContent = "Select coverage amount";
    isValid = false;
  }

  return isValid;
}

function calculatePremium(age, policyType, coverage) {
  let base = 0;

  if (policyType === "Health Insurance") base = 3000;
  else if (policyType === "Life Insurance") base = 5000;
  else if (policyType === "Vehicle Insurance") base = 2000;

  let premium = base;

  if (age > 45) {
    premium = premium + base * 0.2;
  }

  const additionalLakhs = Math.max(0, (coverage - 100000) / 100000);
  premium = premium + additionalLakhs * 500;

  return Math.round(premium);
}

function formatINR(amount) {
  return "₹" + amount.toLocaleString("en-IN");
}

function renderCustomerTable() {
  const filterValue = filterPolicy.value;
  const searchValue = searchName.value.trim().toLowerCase();

  let list = customers;

  if (filterValue !== "") {
    list = list.filter((c) => c.policyType === filterValue);
  }

  if (searchValue !== "") {
    list = list.filter((c) => c.name.toLowerCase().includes(searchValue));
  }

  if (list.length === 0) {
    customerTable.innerHTML = `
      <tr>
        <td colspan="5" class="py-4 text-center text-slate-500">
          No customers found
        </td>
      </tr>
    `;
    updateSummary([]);
    return;
  }

  customerTable.innerHTML = list
    .map((c) => {
      return `
        <tr class="border-b text-slate-700">
          <td class="py-2">${c.name}</td>
          <td class="py-2">${c.age}</td>
          <td class="py-2">${c.policyType}</td>
          <td class="py-2">${c.coverage / 100000} L</td>
          <td class="py-2 font-semibold">${formatINR(c.premium)}</td>
        </tr>
      `;
    })
    .join("");

  updateSummary(list);
}

function updateSummary(list) {
  totalCustomersEl.textContent = list.length;
  const total = list.reduce((sum, customer) => sum + customer.premium, 0);
  totalPremiumEl.textContent = formatINR(total);
}

enquiryForm.addEventListener("submit", function (e) {
  e.preventDefault();

  if (!validateForm()) return;

  const name = customerNameInput.value.trim();
  const age = Number(ageInput.value);
  const policyType = policyTypeInput.value;
  const coverage = Number(coverageInput.value);

  const premium = calculatePremium(age, policyType, coverage);

  const customer = {
    id: Date.now(),
    name: name,
    age: age,
    policyType: policyType,
    coverage: coverage,
    premium: premium,
  };

  customers.push(customer);

  enquiryForm.reset();
  policyTypeInput.value = "";
  coverageInput.value = 100000;

  renderCustomerTable();
});

filterPolicy.addEventListener("change", renderCustomerTable);
searchName.addEventListener("input", renderCustomerTable);

renderCustomerTable();
updateSummary([]);
