using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-COUNT-APOLICOB
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND NUM_ITEM = :WHOST-NUM-ITEM
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.WHOST_NUM_ITEM}'
											WITH UR";

            return query;
        }
        public string WS_COUNT_APOLICOB { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string WHOST_NUM_ITEM { get; set; }

        public static M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1 Execute(M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1 m_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = m_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNT_APOLICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}