using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            , DATA_TERVIGENCIA
            INTO :APOLICOB-DATA-INIVIGENCIA
            , :APOLICOB-DATA-TERVIGENCIA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND DATA_INIVIGENCIA <= :SISTEMA-DTMOVABE
            AND DATA_TERVIGENCIA >= :SISTEMA-DTMOVABE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											, DATA_TERVIGENCIA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND DATA_INIVIGENCIA <= '{this.SISTEMA_DTMOVABE}'
											AND DATA_TERVIGENCIA >= '{this.SISTEMA_DTMOVABE}'
											WITH UR";

            return query;
        }
        public string APOLICOB_DATA_INIVIGENCIA { get; set; }
        public string APOLICOB_DATA_TERVIGENCIA { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1 Execute(M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1 m_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = m_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}