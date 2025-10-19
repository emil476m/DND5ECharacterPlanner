---------------------------------------------------Feats-------------------------------------------------

-- 1. Simple feat (just effect)
INSERT INTO dnd_entity (id, name, is_public, is_official, created_by_user_id, created_at, used_ruleset, entity_type)
VALUES ('00000000-0000-0000-0000-000000000001', 'Keen Mind', true, true, NULL, NOW(), '2014', 1);
INSERT INTO feat (id, effect) VALUES ('00000000-0000-0000-0000-000000000001', 'Always know which way is north');

-- 2. Feat with fixed ability score increase
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000002', 'Athlete', true, true, NULL, NOW(), '2014', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000002', 'Improved athletic ability');
INSERT INTO ability_score_increase (entity_id, ability, amount) VALUES ('00000000-0000-0000-0000-000000000002', 'STR', 1);

-- 3. Feat with multiple ability score increases
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000003', 'Resilient', true, true, NULL, NOW(), '2014', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000003', 'Gain resilience');
INSERT INTO ability_score_increase (entity_id, ability, amount) VALUES
                                                                    ('00000000-0000-0000-0000-000000000003', 'CON', 1),
                                                                    ('00000000-0000-0000-0000-000000000003', 'WIS', 1);

-- 4. Feat with effect choice
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000004', 'Linguist', true, true, NULL, NOW(), '2014', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000004', 'Learn additional languages');
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000004', 'Choose a language to learn', 1, 'Effect');
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (1, 'Elvish'), (1, 'Dwarvish'), (1, 'Draconic');

-- 5. Feat with ability score increase choice
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000005', 'Flexible Mind', true, false, NULL, NOW(), '2024', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000005', 'Choose a mental stat to improve');
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000005', 'Choose an ability to increase', 1, 'AbilityScoreIncrease');
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (2, 'INT+2'), (2, 'WIS+2'), (2, 'CHA+2');

-- 6. Feat with mixed: effect + ability choice
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000006', 'Warrior’s Training', true, false, NULL, NOW(), '2024', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000006', 'Gain training in weapons or improve strength');
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000006', 'Choose a weapon proficiency', 1, 'Effect');
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (3, 'Longsword'), (3, 'Warhammer'), (3, 'Bow');
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000006', 'Choose a stat to increase', 1, 'AbilityScoreIncrease');
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (4, 'STR+1'), (4, 'DEX+1');

-- 7. Simple feat (official = false)
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000007', 'Dungeon Delver', true, false, NULL, NOW(), '2014', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000007', 'You excel at finding hidden doors and traps');

-- 8. Feat with multiple effect choices
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000008', 'Skilled', true, true, NULL, NOW(), '2014', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000008', 'Gain proficiency in skills');
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000008', 'Choose skills', 3, 'Effect');
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (5, 'Stealth'), (5, 'Perception'), (5, 'Investigation'), (5, 'Arcana');

-- 9. Feat with fixed STR + choice of effect
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000009', 'Strong Arm', true, false, NULL, NOW(), '2024', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000009', 'You are stronger and can carry more');
INSERT INTO ability_score_increase (entity_id, ability, amount) VALUES
    ('00000000-0000-0000-0000-000000000009', 'STR', 2);
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000009', 'Choose a special skill', 1, 'Effect');
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (6, 'Intimidation'), (6, 'Athletics');

-- 10. Feat with multiple ability choices
INSERT INTO dnd_entity VALUES ('00000000-0000-0000-0000-000000000010', 'Arcane Gift', true, true, NULL, NOW(), '2024', 1);
INSERT INTO feat VALUES ('00000000-0000-0000-0000-000000000010', 'Gain a magical boost');
INSERT INTO choice (entity_id, description, number_to_choose, type)
VALUES ('00000000-0000-0000-0000-000000000010', 'Choose an ability score to increase', 1, 'AbilityScoreIncrease');
INSERT INTO choice_option (choice_id, value) VALUES(7, 'INT+1'), (7, 'CHA+1'), (7, 'WIS+1');


--------------------------------------------------- PROFICIENCIES -------------------------------------------------
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000001', 'Light Armor');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000002', 'Medium Armor');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000003', 'Heavy Armor');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000004', 'Simple Weapons');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000005', 'Martial Weapons');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000006', 'Thieves Tools');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000007', 'Smith Tools');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000008', 'Mount Proficiency');
INSERT INTO proficiency VALUES ('00000000-0000-0000-0000-000000000009', 'Shield');

--------------------------------------------------- ITEMS -------------------------------------------------

------------------------------------------ 0. ADVENTURING GEAR ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000001', 'Torch', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000001', 0, 'Provides bright light for 1 hour', NULL, 1.00, 1);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000002', 'Rope (50 ft)', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000002', 0, '50 ft hempen rope', NULL, 10.00, 1);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000003', 'Lantern, Hooded', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000003', 0, 'Bright light in 30 ft radius', NULL, 2.00, 5);

------------------------------------------ 1. ARMOR AND SHIELDS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000004', 'Leather Armor', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000004', 1, 'Light armor made of tanned leather', '00000000-0000-0000-0000-000000000001', 10.00, 10);
INSERT INTO armor VALUES('31000000-0000-0000-0000-000000000004', 11, NULL, 0, false, false);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000005', 'Chain Mail', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000005', 1, 'Heavy armor of interlocking rings', '00000000-0000-0000-0000-000000000003', 55.00, 75);
INSERT INTO armor VALUES('31000000-0000-0000-0000-000000000005', 16, 0, 13, false, true);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000006', 'Shield', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000006', 1, 'Provides +2 AC bonus', '00000000-0000-0000-0000-000000000009', 6.00, 10);
INSERT INTO armor VALUES('31000000-0000-0000-0000-000000000006', 2, 0, 0, true, false);

------------------------------------------ 2. POTIONS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000007', 'Potion of Healing', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000007', 2, 'Restores 2d4+2 HP', NULL, 0.50, 50);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000008', 'Potion of Invisibility', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000008', 2, 'Grants invisibility for 1 hour', NULL, 0.50, 500);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000009', 'Potion of Speed', true, true, NULL, NOW(), '2024', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000009', 2, 'Doubles movement for 1 minute', NULL, 0.50, 150);

------------------------------------------ 3. WEAPONS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000010', 'Longsword', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000010', 3, 'Versatile melee weapon', '00000000-0000-0000-0000-000000000005', 3.00, 15);
INSERT INTO weapon VALUES('31000000-0000-0000-0000-000000000010', '1d8', 'Slashing', 'MartialMelee', 'Versatile (1d10)', 5);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000011', 'Shortbow', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000011', 3, 'Simple ranged weapon', '00000000-0000-0000-0000-000000000004', 2.00, 25);
INSERT INTO weapon VALUES('31000000-0000-0000-0000-000000000011', '1d6', 'Piercing', 'SimpleRanged', 'Two-Handed', 80);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000012', 'Dagger', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000012', 3, 'Light, throwable blade', '00000000-0000-0000-0000-000000000004', 1.00, 2);
INSERT INTO weapon VALUES('31000000-0000-0000-0000-000000000012', '1d4', 'Piercing', 'SimpleMelee', 'Finesse, Thrown', 20);

------------------------------------------ 4. SCROLLS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000013', 'Scroll of Fireball', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000013', 4, 'Casts Fireball (Level 3)', NULL, 0.10, 150);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000014', 'Scroll of Shield', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000014', 4, 'Casts Shield reaction (+5 AC)', NULL, 0.10, 100);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000015', 'Scroll of Revivify', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000015', 4, 'Revivifies a recently dead creature', NULL, 0.10, 500);

------------------------------------------ 5. EXPLOSIVES ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000016', 'Alchemist’s Fire', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000016', 5, 'Sticky, flammable liquid', NULL, 1.00, 50);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000017', 'Smokebomb', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000017', 5, 'Obscures 10 ft area for 1 round', NULL, 0.50, 20);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000018', 'Powder Keg', true, false, NULL, NOW(), '2024', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000018', 5, 'Explodes for 6d6 fire damage', NULL, 25.00, 250);

------------------------------------------ 6. WONDROUS ITEMS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000019', 'Cloak of Protection', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000019', 6, 'Grants +1 to AC', NULL, 1.00, 5000);
INSERT INTO wondrous_item VALUES('31000000-0000-0000-0000-000000000019', 'Rare', true);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000020', 'Bag of Holding', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000020', 6, 'Extra-dimensional storage', NULL, 15.00, 2500);
INSERT INTO wondrous_item VALUES('31000000-0000-0000-0000-000000000020', 'Uncommon', false);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000021', 'Boots of Elvenkind', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000021', 6, 'Silences movement', NULL, 2.00, 3000);
INSERT INTO wondrous_item VALUES('31000000-0000-0000-0000-000000000021', 'Uncommon', false);

------------------------------------------ 7. CURRENCY ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000022', 'Gold Coins (100 gp)', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000022', 7, 'Stack of 100 gold coins', NULL, 10.00, NULL);
INSERT INTO currency VALUES('31000000-0000-0000-0000-000000000022', 'gp', 100);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000023', 'Silver Coins (50 sp)', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000023', 7, 'Stack of 50 silver coins', NULL, 5.00, NULL);
INSERT INTO currency VALUES('31000000-0000-0000-0000-000000000023', 'sp', 50);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000024', 'Copper Coins (500 cp)', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000024', 7, 'Stack of 500 copper coins', NULL, 20.00, NULL);
INSERT INTO currency VALUES('31000000-0000-0000-0000-000000000024', 'cp', 500);

------------------------------------------ 8. POISONS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000025', 'Basic Poison', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000025', 8, 'Weak contact poison (1d4 dmg)', NULL, 0.10, 100);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000026', 'Wyvern Poison', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000026', 8, 'Strong venom (7d6 dmg)', NULL, 0.10, 1200);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000027', 'Drow Poison', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000027', 8, 'Injury poison (paralyzes target)', NULL, 0.10, 200);

------------------------------------------ 9. TOOLS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000028', 'Thieves’ Tools', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000028', 9, 'Used to pick locks', '00000000-0000-0000-0000-000000000006', 1.00, 25);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000029', 'Smith’s Tools', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000029', 9, 'Used to forge weapons', '00000000-0000-0000-0000-000000000007', 8.00, 20);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000030', 'Painter’s Supplies', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000030', 9, 'Brushes, pigments, and canvas', NULL, 5.00, 10);

------------------------------------------ 10. SIEGE EQUIPMENT ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000031', 'Ballista', true, false, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000031', 10, 'Large mounted crossbow', NULL, 400.00, 500);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000032', 'Catapult', true, false, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000032', 10, 'Launches heavy stones', NULL, 1500.00, 1000);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000033', 'Battering Ram', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000033', 10, 'Used to breach doors', NULL, 300.00, 200);

------------------------------------------ 11. MOUNT AND VEHICLE ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000034', 'Horse', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000034', 11, 'Riding horse', '00000000-0000-0000-0000-000000000008', 500.00, 75);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000035', 'Warhorse', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000035', 11, 'Trained combat horse', '00000000-0000-0000-0000-000000000008', 600.00, 400);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000036', 'Sailing Ship', true, false, NULL, NOW(), '2024', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000036', 11, 'Large sea vessel', NULL, 20000.00, 10000);

------------------------------------------ 12. TRADE GOODS ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000037', 'Silk Bolt', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000037', 12, 'Fine silk worth 10 gp', NULL, 5.00, 10);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000038', 'Spice Pouch', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000038', 12, 'Exotic spices worth 25 gp', NULL, 1.00, 25);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000039', 'Gemstone', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000039', 12, 'Shiny ruby worth 100 gp', NULL, 0.10, 100);

------------------------------------------ 13. FOOD AND DRINK ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000040', 'Ration Pack', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000040', 13, 'Food for one day', NULL, 2.00, 5);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000041', 'Ale Keg', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000041', 13, 'Keg of dwarven ale', NULL, 20.00, 10);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000042', 'Elven Wine', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000042', 13, 'Fine elven wine bottle', NULL, 1.00, 25);

------------------------------------------ 14. OTHER ------------------------------------------
INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000043', 'Mystery Relic', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000043', 14, 'Unknown ancient object', NULL, 10.00, 500);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000044', 'Broken Compass', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000044', 14, 'Does not point north', NULL, 0.50, 1);

INSERT INTO dnd_entity VALUES('31000000-0000-0000-0000-000000000045', 'Strange Idol', true, false, NULL, NOW(), '2024', 2);
INSERT INTO item VALUES('31000000-0000-0000-0000-000000000045', 14, 'Small statue of unknown origin', NULL, 2.00, 200);

