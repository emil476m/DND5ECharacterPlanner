-- Base table for all DndEntitys
CREATE TABLE IF NOT EXISTS dnd_entity (
    id UUID NOT NULL UNIQUE,
    name VARCHAR(255) NOT NULL UNIQUE,
    is_public BOOLEAN NOT NULL,
    is_official BOOLEAN NOT NULL,
    created_by_user_id UUID NULL,
    created_at DATE NOT NULL,
    used_ruleset VARCHAR(255) NOT NULL,
    entity_type INTEGER NOT NULL,
    PRIMARY KEY (id)
);

----------------------------------------------------------------------------------------------------
---------------------------Feats--------------------------------------------------------------------
----------------------------------------------------------------------------------------------------

--Feats (inherits from dnd_entity) 
CREATE TABLE feat (
    id UUID PRIMARY KEY REFERENCES dnd_entity(id) ON DELETE CASCADE,
    effect VARCHAR(255) NOT NULL
);
-- Ability Score Increases 
CREATE TABLE ability_score_increase (
    id SERIAL PRIMARY KEY,
    entity_id UUID NOT NULL REFERENCES dnd_entity(id) ON DELETE CASCADE,
    ability TEXT NOT NULL, amount INT NOT NULL
);

-- Choices  
CREATE TABLE choice (
    id SERIAL PRIMARY KEY,
    entity_id UUID NOT NULL REFERENCES dnd_entity(id) ON DELETE CASCADE,
    description TEXT NOT NULL, number_to_choose INT NOT NULL,
    type VARCHAR(50) NOT NULL
);

-- Options inside a choice 
CREATE TABLE choice_option (
    id SERIAL PRIMARY KEY,
    choice_id INT NOT NULL REFERENCES choice(id) ON DELETE CASCADE,
    value TEXT NOT NULL
);

----------------------------------------------------------------------------------------------------
---------------------------Profficiencies--------------------------------------------------------------------
----------------------------------------------------------------------------------------------------

--Profficiencies
CREATE TABLE IF NOT EXISTS proficiency (
    id UUID PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE
    );

----------------------------------------------------------------------------------------------------
---------------------------Items--------------------------------------------------------------------
----------------------------------------------------------------------------------------------------


-- Base item table
CREATE TABLE IF NOT EXISTS item (
    id UUID PRIMARY KEY REFERENCES dnd_entity(id) ON DELETE CASCADE,
    item_category INTEGER NOT NULL,  -- 'ArmorAndShields' = 1, 'Weapon' = 3, ...
    description TEXT NULL,
    proficiency UUID NULL REFERENCES proficiency(id),
    weight NUMERIC(8,2) NULL,
    cost INTEGER NULL
    );

-- Armor
CREATE TABLE IF NOT EXISTS armor (
    id UUID PRIMARY KEY REFERENCES item(id) ON DELETE CASCADE,
    armor_class INT NOT NULL,
    max_dex_bonus INT NULL,
    strength_requirement INT NOT NULL,
    is_shield BOOLEAN NOT NULL DEFAULT FALSE,
    stealth_disadvantage BOOLEAN NOT NULL DEFAULT FALSE
);

-- Weapon
CREATE TABLE IF NOT EXISTS weapon (
    id UUID PRIMARY KEY REFERENCES item(id) ON DELETE CASCADE,
    damage VARCHAR(50) NOT NULL,
    damage_type VARCHAR(50) NOT NULL,
    weapon_type VARCHAR(100) NOT NULL,
    properties VARCHAR(255) NULL,
    range INT NOT NULL
);

-- Currency
CREATE TABLE IF NOT EXISTS currency (
    id UUID PRIMARY KEY REFERENCES item(id) ON DELETE CASCADE,
    denomination VARCHAR(10) NOT NULL, -- cp/sp/ep/gp/pp
    amount INT NOT NULL
);

-- Wondrous item
CREATE TABLE IF NOT EXISTS wondrous_item (
    id UUID PRIMARY KEY REFERENCES item(id) ON DELETE CASCADE,
    rarity VARCHAR(50) NULL,
    attunement_required BOOLEAN NOT NULL DEFAULT FALSE
);

-- Adventuring gear
CREATE TABLE IF NOT EXISTS adventuring_gear (
    id UUID PRIMARY KEY REFERENCES item(id) ON DELETE CASCADE,
    gear_type VARCHAR(100) NULL -- e.g. 'rope', 'torch', etc.
);



