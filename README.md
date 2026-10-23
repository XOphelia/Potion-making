# Potion-making
try to find the right combinaison de create new potions

Potion Maker: Technical Report

The player combines up to 3 ingredients in a cauldron to brew a potion. Data, logic and UI are separated, and each script has one purpose.

Data (ScriptableObjects)
IngredientData: stores an ingredient’s name, icon and description. New ingredients are created as assets, with no code changes.
PotionData: stores a potion’s name, icon, liquid color and description.
RecipeData: stores the required ingredients and the resulting potion. Its Matches method checks a list of ingredients against the recipe, ignoring order and handling duplicates.

Fields are [SerializeField] private and exposed through read-only properties, so no other script can modify the data at runtime.

Game systems
InventoryManager: stores ingredient quantities in a dictionary. Add and TryRemove change them and notify listeners.
RecipeBook: holds all recipes and returns the one matching the given ingredients, or null.
CauldronManager: stores the cauldron contents and limits the number of slots. It removes the ingredient from the inventory before adding it, so it can’t be used twice. Clear can refund the ingredients (cancel) or consume them (after brewing).
BrewingController: asks the RecipeBook for a match, fires a success or failure event, then empties the cauldron.
Events
GameEvents: a static class with the game’s events (OnInventoryChanged, OnIngredientAddedToCauldron, OnCauldronCleared, OnBrewSucceeded, OnBrewFailed). Scripts communicate through it instead of referencing each other, so the logic never depends on the UI. Scripts subscribe in OnEnable and unsubscribe in OnDisable to avoid memory leaks and calls on destroyed objects.
UI
IngredientSlotUI: one ingredient slot (icon, name, count). Clicking it asks the cauldron to add the ingredient.
InventoryUI: creates one slot per ingredient from a prefab and refreshes counts when the inventory changes.
CauldronUI: displays the cauldron contents and handles the Brew and Cancel buttons.
ResultUI: shows the resulting potion or a failure message. It sits on an always active object and only its child panel is hidden, otherwise the script would be disabled and unsubscribed from the events.
