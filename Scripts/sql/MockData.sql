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

------------------------------------------------Items------------------------------------------------

-- 1. Armor: Chain Mail
INSERT INTO dnd_entity VALUES('20000000-0000-0000-0000-000000000001', 'Chain Mail', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('20000000-0000-0000-0000-000000000001', 'ArmorAndShields', 'Heavy armor, AC 16, requires proficiency', 55.00, '75 gp');
INSERT INTO armor VALUES('20000000-0000-0000-0000-000000000001', 16, 0, true, 'HeavyArmor', 13, false, true);


-- 2. Weapon: Longsword
INSERT INTO dnd_entity VALUES('20000000-0000-0000-0000-000000000002', 'Longsword', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('20000000-0000-0000-0000-000000000002', 'Weapon', 'Versatile melee weapon', 3.00, '15 gp');
INSERT INTO weapon VALUES('20000000-0000-0000-0000-000000000002', '1d8', 'Slashing', 'MartialMelee', 'Versatile (1d10)', 5);


-- 3. Tool: Thieves'' Tools
INSERT INTO dnd_entity VALUES('20000000-0000-0000-0000-000000000003', 'Thieves'' Tools', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('20000000-0000-0000-0000-000000000003', 'Tool', 'Set of lockpicks, small tools for disabling traps', 1.00, '25 gp');
INSERT INTO tool VALUES('20000000-0000-0000-0000-000000000003', 'ThievesTools');


-- 4. Currency: 100 gp
INSERT INTO dnd_entity VALUES('20000000-0000-0000-0000-000000000004', 'Gold Coins (100 gp)', true, false, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('20000000-0000-0000-0000-000000000004', 'Currency', 'Stack of gold coins', 10.00, NULL);
INSERT INTO currency VALUES('20000000-0000-0000-0000-000000000004', 'gp', 100);


-- 5. Wondrous Item: Cloak of Protection
INSERT INTO dnd_entity VALUES('20000000-0000-0000-0000-000000000005', 'Cloak of Protection', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('20000000-0000-0000-0000-000000000005', 'WondrousItem', 'Grants +1 to AC and saving throws while worn', 1.00, '5000 gp');
INSERT INTO wondrous_item VALUES('20000000-0000-0000-0000-000000000005', 'Very Rare', true);


-- 6. Adventuring Gear: 50ft Rope
INSERT INTO dnd_entity VALUES('20000000-0000-0000-0000-000000000006', '50 ft Hempen Rope', true, true, NULL, NOW(), '2014', 2);
INSERT INTO item VALUES('20000000-0000-0000-0000-000000000006', 'AdventuringGear', '50 feet of hempen rope', 10.00, '1 gp');
INSERT INTO adventuring_gear VALUES('20000000-0000-0000-0000-000000000006', 'Rope');
