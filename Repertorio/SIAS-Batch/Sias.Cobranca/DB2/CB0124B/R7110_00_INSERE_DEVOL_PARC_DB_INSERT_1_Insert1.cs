using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1 : QueryBasis<R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            ( COD_USUARIO
            , DATA_SOLICITACAO
            , IDE_SISTEMA
            , COD_RELATORIO
            , NUM_COPIAS
            , QUANTIDADE
            , PERI_INICIAL
            , PERI_FINAL
            , DATA_REFERENCIA
            , MES_REFERENCIA
            , ANO_REFERENCIA
            , ORGAO_EMISSOR
            , COD_FONTE
            , COD_PRODUTOR
            , RAMO_EMISSOR
            , COD_MODALIDADE
            , COD_CONGENERE
            , NUM_APOLICE
            , NUM_ENDOSSO
            , NUM_PARCELA
            , NUM_CERTIFICADO
            , NUM_TITULO
            , COD_SUBGRUPO
            , COD_OPERACAO
            , COD_PLANO
            , OCORR_HISTORICO
            , NUM_APOL_LIDER
            , ENDOS_LIDER
            , NUM_PARC_LIDER
            , NUM_SINISTRO
            , NUM_SINI_LIDER
            , NUM_ORDEM
            , COD_MOEDA
            , TIPO_CORRECAO
            , SIT_REGISTRO
            , IND_PREV_DEFINIT
            , IND_ANAL_RESUMO
            , COD_EMPRESA
            , PERI_RENOVACAO
            , PCT_AUMENTO
            , TIMESTAMP
            )
            VALUES
            ( 'CB0124B'
            , :SISTEMAS-DATA-MOV-ABERTO
            , 'VA'
            , 'VA0469B'
            , '8'
            , :WS-BCO-RELAT
            , :SISTEMAS-DATA-MOV-ABERTO
            , :SISTEMAS-DATA-MOV-ABERTO
            , :SISTEMAS-DATA-MOV-ABERTO
            , :V0OPCP-AGECTADEB
            , :V0OPCP-OPRCTADEB
            , :V0OPCP-DIGCTADEB
            , 0
            , 0
            , 0
            , 0
            , 0
            , :V0PROP-NUM-APOLICE
            , 0
            , :WS-NUM-PARCELA
            , :V0PROP-NRCERTIF
            , 0
            , :V0PROP-CODSUBES
            , 16
            , 0
            , 0
            , ' '
            , ' '
            , 0
            , :V0OPCP-NUMCTADEB
            , ' '
            , :WS-NUM-ORDEM-RELAT
            , 0
            , ' '
            , '0'
            , ' '
            , ' '
            , NULL
            , 0
            , 0
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( 'CB0124B' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 'VA' , 'VA0469B' , '8' , {FieldThreatment(this.WS_BCO_RELAT)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , {FieldThreatment(this.V0OPCP_AGECTADEB)} , {FieldThreatment(this.V0OPCP_OPRCTADEB)} , {FieldThreatment(this.V0OPCP_DIGCTADEB)} , 0 , 0 , 0 , 0 , 0 , {FieldThreatment(this.V0PROP_NUM_APOLICE)} , 0 , {FieldThreatment(this.WS_NUM_PARCELA)} , {FieldThreatment(this.V0PROP_NRCERTIF)} , 0 , {FieldThreatment(this.V0PROP_CODSUBES)} , 16 , 0 , 0 , ' ' , ' ' , 0 , {FieldThreatment(this.V0OPCP_NUMCTADEB)} , ' ' , {FieldThreatment(this.WS_NUM_ORDEM_RELAT)} , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP )";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WS_BCO_RELAT { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string WS_NUM_PARCELA { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string WS_NUM_ORDEM_RELAT { get; set; }

        public static void Execute(R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1 r7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1)
        {
            var ths = r7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7110_00_INSERE_DEVOL_PARC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}