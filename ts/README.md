# Racing Manager - TypeScript Express

A racing season management application built with TypeScript and Express, featuring multi-season support.

## Features

- Manage multiple racing seasons (2023, 2024, 2025)
- Add races and racers
- Record race results with positions
- Calculate points based on Formula 1-style scoring system
- Track racer standings across the season
- AI racer support

## Installation

```bash
npm install
```

## Development

Run in development mode with auto-reload:

```bash
npm run dev
```

Build the TypeScript code:

```bash
npm run build
```

## Production

Build and run:

```bash
npm run build
npm start
```

The application will be available at `http://localhost:3000`

## Project Structure

- `src/models/RacingSeason.ts` - Core racing season logic
- `src/server.ts` - Express server and API routes
- `public/index.html` - Frontend UI
- `public/app.js` - Frontend JavaScript logic

## API Endpoints

- `GET /api/season/:year` - Get season data
- `POST /api/season/:year/race` - Add a race
- `POST /api/season/:year/racer` - Add a racer
- `POST /api/season/:year/result` - Add a race result
- `GET /api/season/:year/racer/:racerId/positions` - Get racer's positions

## Points System

The application uses a Formula 1-style points system:
- 1st: 25 points
- 2nd: 18 points
- 3rd: 15 points
- 4th: 12 points
- 5th: 10 points
- 6th: 8 points
- 7th: 6 points
- 8th: 4 points
- 9th: 2 points
- 10th: 1 point
