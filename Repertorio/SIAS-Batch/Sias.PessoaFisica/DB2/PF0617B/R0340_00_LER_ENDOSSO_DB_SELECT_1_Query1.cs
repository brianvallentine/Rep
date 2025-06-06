using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PROPOSTA,
            DATA_PROPOSTA,
            DATA_EMISSAO,
            NUM_RCAP,
            VAL_RCAP,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA
            INTO :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE,
            :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO,
            :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA,
            :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA,
            :DCLENDOSSOS.ENDOSSOS-DATA-EMISSAO,
            :DCLENDOSSOS.ENDOSSOS-NUM-RCAP,
            :DCLENDOSSOS.ENDOSSOS-VAL-RCAP,
            :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA,
            :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_ENDOSSO
							,
											NUM_PROPOSTA
							,
											DATA_PROPOSTA
							,
											DATA_EMISSAO
							,
											NUM_RCAP
							,
											VAL_RCAP
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_EMISSAO { get; set; }
        public string ENDOSSOS_NUM_RCAP { get; set; }
        public string ENDOSSOS_VAL_RCAP { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }

        public static R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1 Execute(R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1 r0340_00_LER_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_LER_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_VAL_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}