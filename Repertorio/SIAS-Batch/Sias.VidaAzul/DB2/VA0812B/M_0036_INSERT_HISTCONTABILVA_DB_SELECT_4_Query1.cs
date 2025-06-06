using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1 : QueryBasis<M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO,
            PRMVG,
            PRMAP,
            IMPMORNATU,
            IMPMORACID,
            IMPDIT,
            IMPSEGCDC
            INTO :CBVA-VLPREMIO,
            :CBVA-PRMVG,
            :CBVA-PRMAP,
            :CBVA-IMPMORNATU,
            :CBVA-IMPMORACID,
            :CBVA-IMPDIT,
            :CBVA-IMPSEGCDG
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF =:HCTA-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO
							,
											PRMVG
							,
											PRMAP
							,
											IMPMORNATU
							,
											IMPMORACID
							,
											IMPDIT
							,
											IMPSEGCDC
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF ='{this.HCTA_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'
											WITH UR";

            return query;
        }
        public string CBVA_VLPREMIO { get; set; }
        public string CBVA_PRMVG { get; set; }
        public string CBVA_PRMAP { get; set; }
        public string CBVA_IMPMORNATU { get; set; }
        public string CBVA_IMPMORACID { get; set; }
        public string CBVA_IMPDIT { get; set; }
        public string CBVA_IMPSEGCDG { get; set; }
        public string HCTA_NRCERTIF { get; set; }

        public static M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1 Execute(M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1 m_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1)
        {
            var ths = m_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_4_Query1();
            var i = 0;
            dta.CBVA_VLPREMIO = result[i++].Value?.ToString();
            dta.CBVA_PRMVG = result[i++].Value?.ToString();
            dta.CBVA_PRMAP = result[i++].Value?.ToString();
            dta.CBVA_IMPMORNATU = result[i++].Value?.ToString();
            dta.CBVA_IMPMORACID = result[i++].Value?.ToString();
            dta.CBVA_IMPDIT = result[i++].Value?.ToString();
            dta.CBVA_IMPSEGCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}