import React, {useEffect, useState} from 'react';
import { HubConnectionBuilder } from '@aspnet/signalr';
import Card from "./Card";
import CardGrid from "./CardGrid";

const hub = new HubConnectionBuilder().withUrl('https://localhost:5001/gamehub').build();

 
const Memory = () => {
    const [connected, setConnected] = useState(false);
    const [game, setGame] = useState({});
    const [hasGame, setHasGame] = useState(false);
    
    useEffect(() => {
        hub.start().then(() => console.log("connected")).catch(() => console.log(":("));
        
        hub.on('gameFound', game => {
            setGame(game);
            setHasGame(true);
        });
        
        hub.on('opponentDisconnected', () => {
            console.log('opponent disconnected');
        });
        
        
        return () => {
            hub.off('gameFound');
            hub.off('opponentDisconnected')
            hub.stop().then(() => setConnected(false));
        }
    }, []);

    return (
        <div>
            <h1>Memory</h1>
            {hasGame && (
                <CardGrid>
                    {game.cards.map(card => <Card key={card.id}>card</Card>)}
                </CardGrid>
            )}
        </div>
    );
};

export default Memory;