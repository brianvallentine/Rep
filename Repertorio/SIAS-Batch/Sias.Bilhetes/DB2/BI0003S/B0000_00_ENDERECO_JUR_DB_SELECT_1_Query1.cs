using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1 : QueryBasis<B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO),0)
            INTO :WS-MAX-OCO-END
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :WS-COD-PES-ATU
            AND TIPO_ENDER = 002
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							,0)
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.WS_COD_PES_ATU}'
											AND TIPO_ENDER = 002
											WITH UR";

            return query;
        }
        public string WS_MAX_OCO_END { get; set; }
        public string WS_COD_PES_ATU { get; set; }

        public static B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1 Execute(B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1 b0000_00_ENDERECO_JUR_DB_SELECT_1_Query1)
        {
            var ths = b0000_00_ENDERECO_JUR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_MAX_OCO_END = result[i++].Value?.ToString();
            return dta;
        }

    }
}