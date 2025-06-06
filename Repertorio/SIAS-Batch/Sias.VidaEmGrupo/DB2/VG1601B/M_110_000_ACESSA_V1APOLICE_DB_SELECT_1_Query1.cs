using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODCLIEN,
            NUM_APOLICE,
            MODALIDA,
            ORGAO,
            RAMO,
            NUMBIL,
            TIPAPO
            INTO :APOL-COD-CLIENTE,
            :APOL-NUM-APOLICE,
            :APOL-MODALIDA,
            :APOL-ORGAO,
            :APOL-RAMO,
            :APOL-NUMBIL,
            :APOL-TIPAPO
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :APOL-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODCLIEN
							,
											NUM_APOLICE
							,
											MODALIDA
							,
											ORGAO
							,
											RAMO
							,
											NUMBIL
							,
											TIPAPO
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.APOL_NUM_APOLICE}'";

            return query;
        }
        public string APOL_COD_CLIENTE { get; set; }
        public string APOL_NUM_APOLICE { get; set; }
        public string APOL_MODALIDA { get; set; }
        public string APOL_ORGAO { get; set; }
        public string APOL_RAMO { get; set; }
        public string APOL_NUMBIL { get; set; }
        public string APOL_TIPAPO { get; set; }

        public static M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1 Execute(M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1 m_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOL_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOL_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOL_MODALIDA = result[i++].Value?.ToString();
            dta.APOL_ORGAO = result[i++].Value?.ToString();
            dta.APOL_RAMO = result[i++].Value?.ToString();
            dta.APOL_NUMBIL = result[i++].Value?.ToString();
            dta.APOL_TIPAPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}