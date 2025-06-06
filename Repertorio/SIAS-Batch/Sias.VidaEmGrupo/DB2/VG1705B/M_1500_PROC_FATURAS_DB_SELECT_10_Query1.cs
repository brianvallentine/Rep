using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class M_1500_PROC_FATURAS_DB_SELECT_10_Query1 : QueryBasis<M_1500_PROC_FATURAS_DB_SELECT_10_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(DATA_QUITACAO, DATE( '9999-12-31' ))
            INTO
            :PARCEHIS-DATA-QUITACAO
            FROM
            SEGUROS.PARCELA_HISTORICO
            WHERE
            NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA
            AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO
            AND COD_OPERACAO BETWEEN 200 AND 299
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(DATA_QUITACAO
							, DATE( '9999-12-31' ))
											FROM
											SEGUROS.PARCELA_HISTORICO
											WHERE
											NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCEHIS_NUM_PARCELA}'
											AND OCORR_HISTORICO = '{this.PARCEHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO BETWEEN 200 AND 299";

            return query;
        }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static M_1500_PROC_FATURAS_DB_SELECT_10_Query1 Execute(M_1500_PROC_FATURAS_DB_SELECT_10_Query1 m_1500_PROC_FATURAS_DB_SELECT_10_Query1)
        {
            var ths = m_1500_PROC_FATURAS_DB_SELECT_10_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_PROC_FATURAS_DB_SELECT_10_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_PROC_FATURAS_DB_SELECT_10_Query1();
            var i = 0;
            dta.PARCEHIS_DATA_QUITACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}