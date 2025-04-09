document.getElementById('pokemonForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const nameInput = document.getElementById('pokemonName');
    const name = nameInput.value.trim().toLowerCase();
    const errorDiv = document.getElementById('error');
    const detailsDiv = document.getElementById('pokemonDetails');

    errorDiv.textContent = '';
    detailsDiv.innerHTML = '';

    if (!name) {
        errorDiv.textContent = 'Please enter a Pokémon name';
        return;
    }

    try {
        const response = await fetch(`/api/pokemon/name/${name}`, {
            headers: {
                'Accept': 'application/json'
            }
        });

        if (!response.ok) {
            const message = await response.text();
            throw new Error(message || 'Pokémon not found');
        }

        const pokemon = await response.json();

        const heightInMeters = pokemon.height.toFixed(1);
        const weightInKg = pokemon.weight.toFixed(1);

        detailsDiv.innerHTML = `
            <h2>${pokemon.name.charAt(0).toUpperCase() + pokemon.name.slice(1)}</h2>
            <img class="pokemon-image" src="${pokemon.imageUrl}" alt="${pokemon.name}">
            <p><strong>Type:</strong> ${pokemon.types.join(', ')}</p>
            <p><strong>Height:</strong> ${heightInMeters} m</p>
            <p><strong>Weight:</strong> ${weightInKg} kg</p>
            ${pokemon.evolutions?.next ? `
                <p><strong>Evolves to:</strong> ${pokemon.evolutions.next.name}</p>` : ''}
        `;
    } catch (err) {
        errorDiv.textContent = err.message;
        console.error('Fetch error:', err);
    }
});
