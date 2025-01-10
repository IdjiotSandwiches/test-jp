

async function customFetch(url, options = {}) {
    options.headers = {
        ...options.headers,
        'X-Requested-With': 'XMLHttpRequest',
    }

    try {
        const response = await fetch(url, options);
        if (!response.ok) throw new Error('Not Found');
        return await response.json();
    } catch (error) {
        alert(error);
    }
}

function initPage() {
    const url = `http://localhost:5265/api/invoice/`;
    customFetch(url, {
        method: 'GET',
    }).then(response => {
        const salesName = document.querySelector('#sales_name');
        const courierSelect = document.querySelector('#courier');
        const paymentType = document.querySelector('#payment_type');

        response.courier.forEach(option => {
            let item = `<option value="${option.courierID}">${option.courierName}</option>`;
            courierSelect.insertAdjacentHTML('beforeend', item);
        });

        response.payment.forEach(option => {
            let item = `<option value="${option.paymentID}">${option.paymentName}</option>`;
            paymentType.insertAdjacentHTML('beforeend', item);
        });

        response.sales.forEach(option => {
            let item = `<option value="${option.salesID}">${option.salesName}</option>`;
            salesName.insertAdjacentHTML('beforeend', item);
        });
    });
}

function fetchRequest(url) {
    customFetch(url, {
        'X-Requested-With': 'XMLHttpRequest',
    }).then(response => {
        const salesName = document.querySelector('#sales_name');
        const courierSelect = document.querySelector('#courier');
        const paymentType = document.querySelector('#payment_type');
        const invoiceDate = document.querySelector('#invoice_date');
        const to = document.querySelector('#to');
        const shipTo = document.querySelector('#ship_to');
        const table = document.querySelector('table tbody');
        table.replaceChildren();

        response.items.forEach(item => {
            let row = `<tr>
                <th scope="col">${item.item}</th>
                <th scope="col">${item.weight}</th>
                <th scope="col">${item.qty}</th>
                <th scope="col">${item.price}</th>
                <th scope="col">${item.total}</th>
            </tr>`;
            table.insertAdjacentHTML('beforeend', row);
        });

        changeSelectOption(courierSelect.options, response.invoice.courierID);
        changeSelectOption(paymentType.options, response.invoice.paymentType);
        changeSelectOption(salesName.options, response.invoice.salesID);

        const formattedDate = response.invoice.invoiceDate.split('T')[0];
        invoiceDate.value = formattedDate;
        to.value = response.invoice.invoiceTo;
        shipTo.value = response.invoice.shipTo;

    });
}

function changeSelectOption(options, value) {
    for (let i = 0; i < options.length; i++) {
        options[i].selected = (options[i].value == value);
    }
}

document.addEventListener('DOMContentLoaded', function() {
    initPage();
    document.querySelector('#view').addEventListener('click', function(e) {
        e.preventDefault();
        let val = document.querySelector('#no_invoice').value;
        fetchRequest(`http://localhost:5265/api/invoice/${val}`);
    });
});