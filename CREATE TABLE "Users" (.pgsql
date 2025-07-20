CREATE TABLE "Users" (
    "Id" SERIAL PRIMARY KEY,
    "Username" VARCHAR(100) NOT NULL UNIQUE,
    "PasswordHash" BYTEA NOT NULL,
    "PasswordSalt" BYTEA NOT NULL
);

CREATE TABLE "WorkoutHistories" (
    "Id" SERIAL PRIMARY KEY,
    "Date" VARCHAR(100) NOT NULL,
    "Workout" VARCHAR(255) NOT NULL,
    "Recommendation" VARCHAR(255) NOT NULL,
    "FileAnalyzed" VARCHAR(255),
    "UserId" INTEGER NOT NULL,
    CONSTRAINT fk_user
        FOREIGN KEY("UserId") 
        REFERENCES "Users"("Id") 
        ON DELETE CASCADE
);
