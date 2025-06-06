using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(OCORR_HISTORICO)
            INTO :DCLESTIPULANTE.ESTIPULA-OCORR-HISTORICO:VIND-OCOR
            FROM SEGUROS.ESTIPULANTE
            WHERE COD_CCT = :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE
            AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DTQITBCO
            AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DTQITBCO
            AND COD_FROTA = :DCLESTIPULANTE.ESTIPULA-COD-FROTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(OCORR_HISTORICO)
											FROM SEGUROS.ESTIPULANTE
											WHERE COD_CCT = '{this.CGC_CONVENENTE}'
											AND DATA_INIVIGENCIA <= '{this.DTQITBCO}'
											AND DATA_TERVIGENCIA >= '{this.DTQITBCO}'
											AND COD_FROTA = '{this.ESTIPULA_COD_FROTA}'
											WITH UR";

            return query;
        }
        public string ESTIPULA_OCORR_HISTORICO { get; set; }
        public string VIND_OCOR { get; set; }
        public string CGC_CONVENENTE { get; set; }
        public string ESTIPULA_COD_FROTA { get; set; }
        public string DTQITBCO { get; set; }

        public static R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.ESTIPULA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.VIND_OCOR = string.IsNullOrWhiteSpace(dta.ESTIPULA_OCORR_HISTORICO) ? "-1" : "0";
            return dta;
        }

    }
}