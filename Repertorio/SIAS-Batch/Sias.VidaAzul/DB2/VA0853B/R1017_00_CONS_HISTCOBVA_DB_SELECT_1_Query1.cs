using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DTVENCTO , '0001-01-01' ),
            VALUE(VLPRMTOT , 0),
            VALUE(SITUACAO , '0' ),
            VALUE(NRTIT, 0),
            VALUE(OPCAOPAG, ' ' )
            INTO :V0HICB-DTVENCTO,
            :V0HICB-VLPRMTOT,
            :V0HICB-SITUACAO,
            :WS-NUMERO-TITULO,
            :V0HICB-OPCAO-PGTO
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0PROP-NRPARCEL
            ORDER BY NRTIT
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DTVENCTO 
							, '0001-01-01' )
							,
											VALUE(VLPRMTOT 
							, 0)
							,
											VALUE(SITUACAO 
							, '0' )
							,
											VALUE(NRTIT
							, 0)
							,
											VALUE(OPCAOPAG
							, ' ' )
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0PROP_NRPARCEL}'
											ORDER BY NRTIT
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0HICB_DTVENCTO { get; set; }
        public string V0HICB_VLPRMTOT { get; set; }
        public string V0HICB_SITUACAO { get; set; }
        public string WS_NUMERO_TITULO { get; set; }
        public string V0HICB_OPCAO_PGTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1 Execute(R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1 r1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = r1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HICB_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HICB_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HICB_SITUACAO = result[i++].Value?.ToString();
            dta.WS_NUMERO_TITULO = result[i++].Value?.ToString();
            dta.V0HICB_OPCAO_PGTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}