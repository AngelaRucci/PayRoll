package edu.c3341.nonTerminals;

import edu.c3341.TokenKind;
import edu.c3341.Tokenizer;

public class Write implements NonTerminal{
    Tokenizer tokens;

    public Write(Tokenizer tokens){
        this.tokens = tokens;
    }

    @Override
    public void execute() {
        if(tokens.getToken() != TokenKind.WRITE){
            
        }
        Identifier ids = Identifier.create();
        ids.writeIds(tokens);

    }

    @Override
    public void prettyPrint() {

    }
}
