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
           77  NRTIT                              PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  NRPARCEL                           PIC X(254).
           77  DACPARC                            PIC X(254).
           77  OCORHIST                           PIC X(254).
           77  OTNTOTAL                           PIC X(254).
           77  OTNPRLIQ                           PIC X(254).
           77  OTNADFRA                           PIC X(254).
           77  OTNCUSTO                           PIC X(254).
           77  OTNIOF                             PIC X(254).
           77  QTDDOC                             PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
          NRTIT
    NUM-APOLICE
        NRENDOS
       SITUACAO
       NRPARCEL
        DACPARC
       OCORHIST
       OTNTOTAL
       OTNPRLIQ
       OTNADFRA
       OTNCUSTO
         OTNIOF
         QTDDOC.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT NUM_APOLICE, NRENDOS, SITUACAO, NRPARCEL, DACPARC, OCORHIST, NRTIT, OTNTOTAL, OTNPRLIQ, OTNADFRA, OTNCUSTO, OTNIOF, qtddoc FROM seguros.v1parcelasvg WHERE nrtit = :NRTIT END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
