const API='https://69676d07bbe157c088b1e57b.mockapi.io/Policies';
let policyList = [];
async function fetchPolicies() {

  const res = await fetch(API);
  const data = await res.json();
  let d=document.getElementById('display');
d.innerText = JSON.stringify(data,null,2);
}

fetchPolicies()

async function fetchPolicies() {
  try {
    console.log("Fetching policies...");
    const response = await fetch(API);

    if (!response.ok) {
      throw new Error("Network error");
    }

    const data = await response.json();
    policyList = data;
    console.log("Policies Loaded:", policyList);
  } catch (error) {
    console.log("Error fetching policies:", error.message);
  }
}


//TASK 2
function displayPolicies() {
  const container = document.getElementById("policies");
  container.innerHTML = "";

  policyList.forEach(policy => {
    const div = document.createElement("div");

    div.innerHTML = `
      <h3>${policy.name}</h3>
      <p>Type: ${policy.type}</p>
      <p>Premium: ₹${policy.premium}</p>
      <p>Duration: ${policy.duration} year(s)</p>
      <p>Status: ${policy.status}</p>
    `;

    container.appendChild(div);
  });
}

async function startit() {
  await fetchPolicies();
  displayPolicies();

  // Task 3 — Filter
  console.log("Health Policies:", policyList.filter(p => p.type === "Health"));
  console.log("Life Policies:", policyList.filter(p => p.type === "Life"));
  console.log("Vehicle Policies:", policyList.filter(p => p.type === "Vehicle"));

  // Task 4 — Total Active Premium
  const totalActivePremium = policyList
    .filter(p => p.status === "Active")
    .reduce((sum, p) => sum + p.premium, 0);
  console.log("Total Active Premium:", totalActivePremium);

  // Task 5 — Discount
  const discountedPolicies = policyList.map(p =>
    p.premium > 10000 ? { ...p, premium: p.premium * 0.9 } : p
  );
  console.log("Discounted Policies:", discountedPolicies);




}

// TASK 6
function approvePolicyCallback(policy, callback) {
  setTimeout(() => {
    callback(`Policy "${policy.name}" approved successfully (Callback)`);
  }, 2000);
}

// TASK 7
function approvePolicyPromise(policy) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (policy) {
        resolve(`Policy "${policy.name}" approved successfully (Promise)`);
      } else {
        reject("Invalid policy");
      }
    }, 2000);
  });
}

startit();
