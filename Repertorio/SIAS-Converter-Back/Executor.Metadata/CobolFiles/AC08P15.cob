       IDENTIFICATION DIVISION.                                                 
       PROGRAM-ID. AC10P013.                                                    
                                                                                
      *---------------------*                                                   
       ENVIRONMENT DIVISION.                                                    
      *---------------------*                                                   
                                                                                
      *---------------------*                                                   
       CONFIGURATION SECTION.                                                   
      *---------------------*                                                   
                                                                                
      *-------------*                                                           
       SPECIAL-NAMES.                                                           
      *-------------*                                                           
           DECIMAL-POINT IS COMMA.                                              
                                                                                
      *--------------------*                                                    
       INPUT-OUTPUT SECTION.                                                    
      *--------------------*                                                    
                                                                                
      *-------------*                                                           
       DATA DIVISION.                                                           
      *-------------*                                                           
      *                                                                         
      *-----------------------*                                                 
       WORKING-STORAGE SECTION.                                                 
      *-----------------------*                                                 
             
      *----------------------------------------------------------------*        
      *- VARIAVEIS AUXILIARES                                          *        
      *----------------------------------------------------------------*        
                                                                                     
      *>    05  LK-TIP-CALC                        PIC 9(001) VALUE ZEROS .            
      *>    05  LK-NUM-APOL                        PIC 9(001) VALUE ZEROS .           
      *>    05  LK-NRENDOS                         PIC 9(001) VALUE ZEROS .   
      *>    05  LK-DTINIVIG                     OCCURS      2000   TIMES               
      *>                                        INDEXED      BY    WIND.          
      *>        10      WTABG-CODPRODU             PIC S9(004)        COMP.               
      *>            15  WTABG-OCORRETIP         OCCURS       003   TIMES       
      *>                                        INDEXED      BY    WIND2.     
      *>                25    WTABG-TIPO  PIC  X(001).                 

      *>   77  LK-TIP-CALC                        PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  CONGENER                           PIC X(254).
           77  VLPREMIO                           PIC X(254).
           77  VLRCOMIS                           PIC X(254).
           77  VLRSINI                            PIC X(254).
           77  VLRDESCON                          PIC X(254).
           77  VLRADIFRA                          PIC X(254).
           77  VLDESPESA                          PIC X(254).
           77  VLRHONOR                           PIC X(254).
           77  VLRSALVD                           PIC X(254).
           77  VLRESSARC                          PIC X(254).
           77  VALOR-EDI                          PIC X(254).
           77  VALOR-USS                          PIC X(254).
           77  VLEQPVNDA                          PIC X(254).
           77  VLDESPADM                          PIC X(254).
           77  OUTRDEBIT                          PIC X(254).
           77  OUTRCREDT                          PIC X(254).
           77  VLRSLDANT                          PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
       SITUACAO
       CONGENER
       VLPREMIO
       VLRCOMIS
        VLRSINI
      VLRDESCON
      VLRADIFRA
      VLDESPESA
       VLRHONOR
       VLRSALVD
      VLRESSARC
      VALOR-EDI
      VALOR-USS
      VLEQPVNDA
      VLDESPADM
      OUTRDEBIT
      OUTRCREDT
      VLRSLDANT.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT congener, vlpremio, vlrcomis, vlrsini, vlrdescon, vlradifra, vldespesa, vlrhonor, vlrsalvd, vlressarc, valor_edi, valor_uss, vleqpvnda, vldespadm, outrdebit, outrcredt, vlrsldant FROM seguros.v0cosced_cheque WHERE situacao = ' ' and dtmovto_fi is null ORDER BY congener END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
