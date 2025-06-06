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
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOSC                           PIC X(254).
           77  NRPARCELC                          PIC X(254).
           77  NRENDOSR                           PIC X(254).
           77  NRPARCELR                          PIC X(254).
           77  DTEMIS                             PIC X(254).
           77  VALCREDR-IX                        PIC X(254).
           77  DTVENCTO                           PIC X(254).
           77  CODUNIMO                           PIC X(254).
           77  OCORHIST                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
       NRENDOSC
      NRPARCELC
       NRENDOSR
      NRPARCELR
         DTEMIS
    VALCREDR-IX
       DTVENCTO
       CODUNIMO
       OCORHIST.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NRENDOSR, NRPARCELR, NRENDOSC, NRPARCELC, DTEMIS, VALCREDR_IX, DTVENCTO, CODUNIMO, OCORHIST FROM seguros.v1notascred WHERE num_apolice = :NUM_APOLICE AND nrendosc = :NRENDOSC AND nrparcelc = :NRPARCELC AND situacao = '0' END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
