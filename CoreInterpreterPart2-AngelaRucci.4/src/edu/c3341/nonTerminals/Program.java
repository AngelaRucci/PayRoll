package edu.c3341;

import edu.c3341.nonTerminals.nonTerminal;

public class program implements nonTerminal {
    private Tokenizer2 tokens;

    public program(Tokenizer2 tokens){
        this.tokens = tokens;
    }


    @Override
    public void execute() {
        if(tokens.getToken() != TokenKind.PROGRAM){
            System.out.print("Program must start with 'Program' ");
        }
        tokens.skipToken();

//        Declaration Sequence

        tokens.skipToken();
        if(tokens.getToken() != TokenKind.BEGIN){
            System.out.print("'Begin' is missing ");
        }
        tokens.skipToken();

//        statement sequence


    }

    @Override
    public void prettyPrint() {

    }
}
