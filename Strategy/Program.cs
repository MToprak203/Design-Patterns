// Create a character
Character character = new Character();

// Set initial attack strategy (e.g., sword)
character.SetAttackStrategy(new SwordAttackStrategy());

// Perform attack
character.PerformAttack();

// Switch attack strategy (e.g., bow)
character.SetAttackStrategy(new BowAttackStrategy());

// Perform attack
character.PerformAttack();

// Switch attack strategy (e.g., magic)
character.SetAttackStrategy(new MagicAttackStrategy());

// Perform attack
character.PerformAttack();