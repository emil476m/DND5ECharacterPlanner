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