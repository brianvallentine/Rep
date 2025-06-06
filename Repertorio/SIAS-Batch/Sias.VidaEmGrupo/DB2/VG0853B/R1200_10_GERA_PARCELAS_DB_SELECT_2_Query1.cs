using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1 : QueryBasis<R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_PARCELA_DESC
            INTO :DESCON-PERC
            FROM SEGUROS.VG_PARCELAS_DESCON
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO IN (:V0PROP-CODSUBES, 0)
            AND NUM_PARCELA_DESC = :V0PROP-NRPARCEL
            AND DT_INIVIG_PARCDESC <= :V0PROP-DTQITBCO
            AND DT_TERVIG_PARCDESC >= :V0PROP-DTQITBCO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_PARCELA_DESC
											FROM SEGUROS.VG_PARCELAS_DESCON
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO IN ('{this.V0PROP_CODSUBES}'
							, 0)
											AND NUM_PARCELA_DESC = '{this.V0PROP_NRPARCEL}'
											AND DT_INIVIG_PARCDESC <= '{this.V0PROP_DTQITBCO}'
											AND DT_TERVIG_PARCDESC >= '{this.V0PROP_DTQITBCO}'";

            return query;
        }
        public string DESCON_PERC { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_DTQITBCO { get; set; }

        public static R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1 Execute(R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1 r1200_10_GERA_PARCELAS_DB_SELECT_2_Query1)
        {
            var ths = r1200_10_GERA_PARCELAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.DESCON_PERC = result[i++].Value?.ToString();
            return dta;
        }

    }
}