using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1 : QueryBasis<R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_PARCELA_DESC
            INTO :DESCON-PERC
            FROM SEGUROS.VG_PARCELAS_DESCON
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = :V0PROP-CODSUBES
            AND NUM_PARCELA_DESC = :DESCON-NRPARCEL
            AND DT_INIVIG_PARCDESC <= :V0PROP-DTADMISSAO
            AND DT_TERVIG_PARCDESC >= :V0PROP-DTADMISSAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_PARCELA_DESC
											FROM SEGUROS.VG_PARCELAS_DESCON
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'
											AND NUM_PARCELA_DESC = '{this.DESCON_NRPARCEL}'
											AND DT_INIVIG_PARCDESC <= '{this.V0PROP_DTADMISSAO}'
											AND DT_TERVIG_PARCDESC >= '{this.V0PROP_DTADMISSAO}'
											WITH UR";

            return query;
        }
        public string DESCON_PERC { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_DTADMISSAO { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string DESCON_NRPARCEL { get; set; }

        public static R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1 Execute(R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1 r5000_00_GERA_PROXIMA_DB_SELECT_3_Query1)
        {
            var ths = r5000_00_GERA_PROXIMA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1();
            var i = 0;
            dta.DESCON_PERC = result[i++].Value?.ToString();
            return dta;
        }

    }
}