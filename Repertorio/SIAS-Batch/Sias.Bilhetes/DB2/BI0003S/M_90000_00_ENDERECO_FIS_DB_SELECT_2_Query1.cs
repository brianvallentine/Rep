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
    public class M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 : QueryBasis<M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CEP
            INTO :DCLPESSOA-ENDERECO.CEP
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :WS-COD-PES-ATU
            AND TIPO_ENDER = 001
            AND OCORR_ENDERECO = :WS-MAX-OCO-END
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CEP
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.WS_COD_PES_ATU}'
											AND TIPO_ENDER = 001
											AND OCORR_ENDERECO = '{this.WS_MAX_OCO_END}'
											WITH UR";

            return query;
        }
        public string CEP { get; set; }
        public string WS_COD_PES_ATU { get; set; }
        public string WS_MAX_OCO_END { get; set; }

        public static M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 Execute(M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1)
        {
            var ths = m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1();
            var i = 0;
            dta.CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}