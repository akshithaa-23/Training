const form = document.querySelector('.formbox');

form.addEventListener('submit', function(e) {
    e.preventDefault();
    clearAllErrors();
    const name = document.getElementById('fname').value.trim();
    const email = document.getElementById('email').value.trim();
    const mobile = document.getElementById('mno').value.trim();
    const requestType = document.getElementById('requestType').value;
    const policyType = document.getElementById('policyType').value;
    const message = document.getElementById('message').value.trim();
    const rating = document.querySelector('input[name="rating"]:checked');
    let isValid = true;
    if (name === '') {
        showError('fname', 'Name is required');
        isValid = false;
    }
    if (email === '') {
        showError('email', 'Email is required');
        isValid = false;
    }
    if (mobile === '') {
        showError('mno', 'Mobile number is required');
        isValid = false;
    } else if (!/^\d{10}$/.test(mobile)) {
        showError('mno', 'Mobile number must be exactly 10 digits');
        isValid = false;
    }
    if (requestType === '') {
        showError('requestType', 'Please select a request type');
        isValid = false;
    }
    if (policyType === '') {
        showError('policyType', 'Please select a policy type');
        isValid = false;
    }
    if (message === '') {
        showError('message', 'Message is required');
        isValid = false;
    } else if (message.length < 10) {
        showError('message', 'Message must be at least 10 characters long');
        isValid = false;
    }
    if (!rating) {
        showError('rating', 'Please select experience rating');
        isValid = false;
    }
    
    if (isValid) {
        showSuccess();
        form.reset();
    }
});

function showError(fieldId, errorMessage) {
    const field = document.getElementById(fieldId);
    
    const errorDiv = document.createElement('div');
    errorDiv.className = 'error-message';
    errorDiv.textContent = errorMessage;
    errorDiv.style.color = '#d32f2f';
    errorDiv.style.fontSize = '14px';
    errorDiv.style.marginTop = '5px';
    errorDiv.style.marginBottom = '10px';
    field.parentNode.insertBefore(errorDiv, field.nextSibling);
}

function clearAllErrors() {
    const errorMessages = document.querySelectorAll('.error-message');
    errorMessages.forEach(error => error.remove());
  
    const successMessage = document.querySelector('.success-message');
    if (successMessage) {
        successMessage.remove();
    }
}

function showSuccess() {
    const successDiv = document.createElement('div');
    successDiv.className = 'success-message';
    successDiv.textContent = 'Thank you! Your enquiry has been successfully submitted.';
    successDiv.style.backgroundColor = '#4caf50';
    successDiv.style.color = 'white';
    successDiv.style.padding = '15px';
    successDiv.style.borderRadius = '5px';
    successDiv.style.marginBottom = '20px';
    successDiv.style.textAlign = 'center';
    successDiv.style.fontSize = '16px';
    successDiv.style.fontWeight = 'bold';

    form.insertBefore(successDiv, form.firstChild);
    setTimeout(() => {
        successDiv.remove();
    }, 3000);
}
