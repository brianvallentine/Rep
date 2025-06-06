using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005S
{
    public class M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1 : QueryBasis<M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO),0)
            INTO :WS-MAX-OCO-END
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            AND TIPO_ENDER = 001
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							,0)
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.BI0005L_E_COD_PESSOA}'
											AND TIPO_ENDER = 001
											WITH UR";

            return query;
        }
        public string WS_MAX_OCO_END { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }

        public static M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1 Execute(M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1 m_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1)
        {
            var ths = m_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_MAX_OCO_END = result[i++].Value?.ToString();
            return dta;
        }

    }
}