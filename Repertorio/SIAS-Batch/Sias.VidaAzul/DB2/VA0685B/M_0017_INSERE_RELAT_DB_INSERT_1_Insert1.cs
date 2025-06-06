using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0017_INSERE_RELAT_DB_INSERT_1_Insert1 : QueryBasis<M_0017_INSERE_RELAT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS (
            COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA,
            COD_RELATORIO, NUM_COPIAS, QUANTIDADE,
            PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA,
            MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR,
            COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR,
            COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE,
            NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO,
            NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO,
            COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER,
            ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO,
            NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA,
            TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT,
            IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO,
            PCT_AUMENTO, TIMESTAMP)
            SELECT 'VA0685B' , CURRENT DATE, 'VA' , 'VA0685B' , 0, 0,
            '2008-08-01' , '9999-12-31' , CURRENT DATE,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' ,
            ' ' , ' ' , 0, 0, 0.00, CURRENT TIMESTAMP
            FROM SYSIBM.SYSDUMMY1
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA, COD_RELATORIO, NUM_COPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR, COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO, NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO, COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER, ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA, TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT, IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) SELECT 'VA0685B' , CURRENT DATE, 'VA' , 'VA0685B' , 0, 0, '2008-08-01' , '9999-12-31' , CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0.00, CURRENT TIMESTAMP FROM SYSIBM.SYSDUMMY1";

            return query;
        }

        public static void Execute(M_0017_INSERE_RELAT_DB_INSERT_1_Insert1 m_0017_INSERE_RELAT_DB_INSERT_1_Insert1)
        {
            var ths = m_0017_INSERE_RELAT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0017_INSERE_RELAT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}