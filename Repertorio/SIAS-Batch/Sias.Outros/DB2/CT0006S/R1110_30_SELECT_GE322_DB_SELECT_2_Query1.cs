using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CT0006S
{
    public class R1110_30_SELECT_GE322_DB_SELECT_2_Query1 : QueryBasis<R1110_30_SELECT_GE322_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NOM_TP_LOGRADOURO,
            A.NOM_LOGRADOURO,
            C.NOM_BAIRRO,
            B.NOM_LOCALIDADE
            INTO
            :GE322-NOM-TP-LOGRADOURO ,
            :GE322-NOM-LOGRADOURO ,
            :GE329-NOM-BAIRRO ,
            :GE324-NOM-LOCALIDADE
            FROM SEGUROS.GE_DNE_UNID_OPER A,
            SEGUROS.GE_DNE_LOCALIDADE B,
            SEGUROS.GE_DNE_BAIRRO C
            WHERE A.COD_CEP = :GE322-COD-CEP
            AND A.NUM_LOCALIDADE = B.NUM_LOCALIDADE
            AND B.NUM_LOCALIDADE = C.NUM_LOCALIDADE
            AND A.NUM_BAIRRO = C.NUM_BAIRRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NOM_TP_LOGRADOURO
							,
											A.NOM_LOGRADOURO
							,
											C.NOM_BAIRRO
							,
											B.NOM_LOCALIDADE
											FROM SEGUROS.GE_DNE_UNID_OPER A
							,
											SEGUROS.GE_DNE_LOCALIDADE B
							,
											SEGUROS.GE_DNE_BAIRRO C
											WHERE A.COD_CEP = '{this.GE322_COD_CEP}'
											AND A.NUM_LOCALIDADE = B.NUM_LOCALIDADE
											AND B.NUM_LOCALIDADE = C.NUM_LOCALIDADE
											AND A.NUM_BAIRRO = C.NUM_BAIRRO";

            return query;
        }
        public string GE322_NOM_TP_LOGRADOURO { get; set; }
        public string GE322_NOM_LOGRADOURO { get; set; }
        public string GE329_NOM_BAIRRO { get; set; }
        public string GE324_NOM_LOCALIDADE { get; set; }
        public string GE322_COD_CEP { get; set; }

        public static R1110_30_SELECT_GE322_DB_SELECT_2_Query1 Execute(R1110_30_SELECT_GE322_DB_SELECT_2_Query1 r1110_30_SELECT_GE322_DB_SELECT_2_Query1)
        {
            var ths = r1110_30_SELECT_GE322_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_30_SELECT_GE322_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_30_SELECT_GE322_DB_SELECT_2_Query1();
            var i = 0;
            dta.GE322_NOM_TP_LOGRADOURO = result[i++].Value?.ToString();
            dta.GE322_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.GE329_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.GE324_NOM_LOCALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}