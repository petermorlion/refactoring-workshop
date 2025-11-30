import { v4 as uuidv4 } from 'uuid';

export class RacingSeason {
    private _races: Map<string, string> = new Map();
    private _racers: Map<string, string> = new Map();
    private _positions: Map<string, number> = new Map();

    addRace(raceName: string): string {
        const raceId = uuidv4();
        this._races.set(raceId, raceName);
        return raceId;
    }

    getRaces(): Map<string, string> {
        return this._races;
    }

    addRacer(racerName: string, isAI: boolean): string {
        const racerId = uuidv4();
        if (isAI) {
            racerName = `${racerName} [AI]`;
        }

        this._racers.set(racerId, racerName);
        return racerId;
    }

    getRacers(): Map<string, string> {
        return this._racers;
    }

    addResult(raceId: string, racerId: string, position: number): void {
        const key = `${raceId}|${racerId}`;
        this._positions.set(key, position);
    }

    getRacerPositions(racerId: string): { raceName: string, position: number }[] {
        const results: { raceName: string, position: number }[] = [];
        for (const position of this._positions) {
            const [raceId, posRacerId] = position[0].split('|');
            if (posRacerId === racerId) {
                results.push({ raceName: this._races.get(raceId)!, position: position[1] });
            }
        }
        return results;
    }

    getResults(): Map<string, number> {
        const results = new Map<string, number>();
        for (const racer of this._racers) {
            let totalPoints = 0;
            for (const position of this._positions) {
                const [, posRacerId] = position[0].split('|');
                if (posRacerId === racer[0]) {
                    let points = 0;
                    switch (position[1]) {
                        case 1:
                            points = 25;
                            break;
                        case 2:
                            points = 18;
                            break;
                        case 3:
                            points = 15;
                            break;
                        case 4:
                            points = 12;
                            break;
                        case 5:
                            points = 10;
                            break;
                        case 6:
                            points = 8;
                            break;
                        case 7:
                            points = 6;
                            break;
                        case 8:
                            points = 4;
                            break;
                        case 9:
                            points = 2;
                            break;
                        case 10:
                            points = 1;
                            break;
                    }

                    totalPoints += points;
                }
            }
            results.set(`${racer[0]}|${racer[1]}`, totalPoints);
        }

        return new Map([...results.entries()].sort((a, b) => b[1] - a[1]));
    }
}
