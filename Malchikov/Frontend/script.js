async function FillCards() {
    const response = await fetch("http://localhost:5043/Shop");
    const data = await response.json();

console.log("123");

    let container = document.getElementById('card-list');

    container.innerHTML = '';

    data.forEach(element => {
        let card = document.createElement('div');
        console.log(element)
        const cardHTML =`
        <h3>${element.id}</h3>
        <h3>${element.name}</h3>
        <h3>${element.quantity}</h3>
        <h3>${element.priceShop}</h3>
        <h3>${element.supplierId}</h3>
        <h3>${element.assortmentId}</h3>
        <h3>${element.assortment}</h3>
        <h3>${element.supplier}</h3>
        `;
        card.innerHTML = cardHTML;
        card.classList.add("card");
        console.log(element);
        container.appendChild(card)
    });
}

FillCards();