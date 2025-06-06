using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.RELATORIOS
            (COD_USUARIO
            ,DATA_SOLICITACAO
            ,IDE_SISTEMA
            ,COD_RELATORIO
            ,NUM_COPIAS
            ,QUANTIDADE
            ,PERI_INICIAL
            ,PERI_FINAL
            ,DATA_REFERENCIA
            ,MES_REFERENCIA
            ,ANO_REFERENCIA
            ,ORGAO_EMISSOR
            ,COD_FONTE
            ,COD_PRODUTOR
            ,RAMO_EMISSOR
            ,COD_MODALIDADE
            ,COD_CONGENERE
            ,NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,NUM_CERTIFICADO
            ,NUM_TITULO
            ,COD_SUBGRUPO
            ,COD_OPERACAO
            ,COD_PLANO
            ,OCORR_HISTORICO
            ,NUM_APOL_LIDER
            ,ENDOS_LIDER
            ,NUM_PARC_LIDER
            ,NUM_SINISTRO
            ,NUM_SINI_LIDER
            ,NUM_ORDEM
            ,COD_MOEDA
            ,TIPO_CORRECAO
            ,SIT_REGISTRO
            ,IND_PREV_DEFINIT
            ,IND_ANAL_RESUMO
            ,COD_EMPRESA
            ,PERI_RENOVACAO
            ,PCT_AUMENTO
            ,TIMESTAMP)
            VALUES
            ( 'BI8070B'
            ,:SISTEMA-DTMOVABE
            , 'BI'
            ,:RELATORI-COD-RELATORIO
            ,0
            ,0
            ,:SISTEMA-DTMOVABE
            ,:SISTEMA-DTMOVABE
            ,:SISTEMA-DTMOVABE
            ,0
            ,0
            ,0
            ,0
            ,0
            ,0
            ,0
            ,0
            ,:RELATORI-NUM-APOLICE
            ,:RELATORI-NUM-ENDOSSO
            ,0
            ,:RELATORI-NUM-CERTIFICADO
            ,:RELATORI-NUM-TITULO
            ,0
            ,:RELATORI-COD-OPERACAO
            ,0
            ,0
            , ' '
            , ' '
            ,0
            ,0
            , ' '
            ,0
            ,0
            , ' '
            , '0'
            , ' '
            , ' '
            ,NULL
            ,0
            ,0
            ,CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO ,DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,NUM_COPIAS ,QUANTIDADE ,PERI_INICIAL ,PERI_FINAL ,DATA_REFERENCIA ,MES_REFERENCIA ,ANO_REFERENCIA ,ORGAO_EMISSOR ,COD_FONTE ,COD_PRODUTOR ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_CONGENERE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_TITULO ,COD_SUBGRUPO ,COD_OPERACAO ,COD_PLANO ,OCORR_HISTORICO ,NUM_APOL_LIDER ,ENDOS_LIDER ,NUM_PARC_LIDER ,NUM_SINISTRO ,NUM_SINI_LIDER ,NUM_ORDEM ,COD_MOEDA ,TIPO_CORRECAO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO ,COD_EMPRESA ,PERI_RENOVACAO ,PCT_AUMENTO ,TIMESTAMP) VALUES ( 'BI8070B' ,{FieldThreatment(this.SISTEMA_DTMOVABE)} , 'BI' ,{FieldThreatment(this.RELATORI_COD_RELATORIO)} ,0 ,0 ,{FieldThreatment(this.SISTEMA_DTMOVABE)} ,{FieldThreatment(this.SISTEMA_DTMOVABE)} ,{FieldThreatment(this.SISTEMA_DTMOVABE)} ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,{FieldThreatment(this.RELATORI_NUM_APOLICE)} ,{FieldThreatment(this.RELATORI_NUM_ENDOSSO)} ,0 ,{FieldThreatment(this.RELATORI_NUM_CERTIFICADO)} ,{FieldThreatment(this.RELATORI_NUM_TITULO)} ,0 ,{FieldThreatment(this.RELATORI_COD_OPERACAO)} ,0 ,0 , ' ' , ' ' ,0 ,0 , ' ' ,0 ,0 , ' ' , '0' , ' ' , ' ' ,NULL ,0 ,0 ,CURRENT TIMESTAMP)";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }

        public static void Execute(R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1 r4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}