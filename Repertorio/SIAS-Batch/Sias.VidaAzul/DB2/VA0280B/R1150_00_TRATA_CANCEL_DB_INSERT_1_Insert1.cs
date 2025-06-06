using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1 : QueryBasis<R1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS (
            COD_USUARIO,
            DATA_SOLICITACAO,
            IDE_SISTEMA,
            COD_RELATORIO,
            NUM_COPIAS,
            QUANTIDADE,
            PERI_INICIAL,
            PERI_FINAL,
            DATA_REFERENCIA,
            MES_REFERENCIA,
            ANO_REFERENCIA,
            ORGAO_EMISSOR,
            COD_FONTE,
            COD_PRODUTOR,
            RAMO_EMISSOR,
            COD_MODALIDADE,
            COD_CONGENERE,
            NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PARCELA,
            NUM_CERTIFICADO,
            NUM_TITULO,
            COD_SUBGRUPO,
            COD_OPERACAO,
            COD_PLANO,
            OCORR_HISTORICO,
            NUM_APOL_LIDER,
            ENDOS_LIDER,
            NUM_PARC_LIDER,
            NUM_SINISTRO,
            NUM_SINI_LIDER,
            NUM_ORDEM,
            COD_MOEDA,
            TIPO_CORRECAO,
            SIT_REGISTRO,
            IND_PREV_DEFINIT,
            IND_ANAL_RESUMO,
            COD_EMPRESA,
            PERI_RENOVACAO,
            PCT_AUMENTO,
            TIMESTAMP)
            VALUES ( 'VA0280B' ,
            :V1SIST-DTMOVABE,
            'VA' ,
            'VA0437B' ,
            0,
            0,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :PROPOVA-NUM-APOLICE,
            0,
            2,
            :PROPOVA-NUM-CERTIFICADO,
            0,
            0,
            2,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            0,
            0,
            0.00,
            CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA, COD_RELATORIO, NUM_COPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR, COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO, NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO, COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER, ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA, TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT, IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) VALUES ( 'VA0280B' , {FieldThreatment(this.V1SIST_DTMOVABE)}, 'VA' , 'VA0437B' , 0, 0, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.PROPOVA_NUM_APOLICE)}, 0, 2, {FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, 0, 0, 2, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0.00, CURRENT TIMESTAMP )";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1 r1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1)
        {
            var ths = r1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1150_00_TRATA_CANCEL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}