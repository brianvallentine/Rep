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
           77  COD-EMPRESA                        PIC X(254).
           77  BCOAVISO                           PIC X(254).
           77  AGEAVISO                           PIC X(254).
           77  TIPSGU                             PIC X(254).
           77  NRAVISO                            PIC X(254).
           77  DTAVISO                            PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  SDOATU                             PIC X(254).
           77  SITUACAO                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    COD-EMPRESA
       BCOAVISO
       AGEAVISO
         TIPSGU
        NRAVISO
        DTAVISO
        DTMOVTO
         SDOATU
       SITUACAO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0avisos_saldos (COD_EMPRESA, BCOAVISO, AGEAVISO, TIPSGU, NRAVISO, DTAVISO, DTMOVTO, SDOATU, SITUACAO) VALUES (:COD_EMPRESA, :BCOAVISO, :AGEAVISO, :TIPSGU, :NRAVISO, :DTAVISO, :DTMOVTO, :SDOATU, :SITUACAO) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
