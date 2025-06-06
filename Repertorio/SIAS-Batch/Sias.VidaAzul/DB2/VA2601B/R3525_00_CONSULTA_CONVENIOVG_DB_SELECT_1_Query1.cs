using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 : QueryBasis<R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SEGURO
            , COD_CONV_CARTAO
            INTO :CONVEVG-COD-SEGURO
            , :CONVEVG-COD-CONV-CARTAO
            FROM SEGUROS.CONVENIOS_VG
            WHERE NUM_APOLICE = :CONVEVG-NUM-APOLICE
            AND CODSUBES = :CONVEVG-CODSUBES
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_SEGURO
											, COD_CONV_CARTAO
											FROM SEGUROS.CONVENIOS_VG
											WHERE NUM_APOLICE = '{this.CONVEVG_NUM_APOLICE}'
											AND CODSUBES = '{this.CONVEVG_CODSUBES}'
											WITH UR";

            return query;
        }
        public string CONVEVG_COD_SEGURO { get; set; }
        public string CONVEVG_COD_CONV_CARTAO { get; set; }
        public string CONVEVG_NUM_APOLICE { get; set; }
        public string CONVEVG_CODSUBES { get; set; }

        public static R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 Execute(R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 r3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1)
        {
            var ths = r3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVEVG_COD_SEGURO = result[i++].Value?.ToString();
            dta.CONVEVG_COD_CONV_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}