using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1 : QueryBasis<M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PROCESSO_JURID
            INTO :SI042-COD-PROCESSO-JURID
            FROM SEGUROS.SI_DETALHE_PROC_JURID
            WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI
            AND OCORR_HISTORICO = :THIST-OCORHIST
            AND COD_OPERACAO = :THIST-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PROCESSO_JURID
											FROM SEGUROS.SI_DETALHE_PROC_JURID
											WHERE NUM_APOL_SINISTRO = '{this.RELSIN_APOL_SINI}'
											AND OCORR_HISTORICO = '{this.THIST_OCORHIST}'
											AND COD_OPERACAO = '{this.THIST_OPERACAO}'";

            return query;
        }
        public string SI042_COD_PROCESSO_JURID { get; set; }
        public string RELSIN_APOL_SINI { get; set; }
        public string THIST_OCORHIST { get; set; }
        public string THIST_OPERACAO { get; set; }

        public static M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1 Execute(M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1 m_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1)
        {
            var ths = m_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI042_COD_PROCESSO_JURID = result[i++].Value?.ToString();
            return dta;
        }

    }
}