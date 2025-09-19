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
INSERT INTO choice_option (choice_id, value) VALUES
                                                 (7, 'INT+1'), (7, 'CHA+1'), (7, 'WIS+1');