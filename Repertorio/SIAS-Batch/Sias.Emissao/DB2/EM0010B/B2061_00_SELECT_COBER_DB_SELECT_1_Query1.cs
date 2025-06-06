using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2061_00_SELECT_COBER_DB_SELECT_1_Query1 : QueryBasis<B2061_00_SELECT_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT LTMVPRCO.VAL_IMP_SEGURADA
            , LTMVPRCO.VAL_TAXA_PREMIO
            INTO :LTMVPRCO-VAL-IMP-SEGURADA
            , :LTMVPRCO-VAL-TAXA-PREMIO
            FROM SEGUROS.LT_MOV_PROP_COBER LTMVPRCO
            WHERE LTMVPRCO.COD_EXT_SEGURADO = :LTMVPRCO-COD-EXT-SEGURADO
            AND LTMVPRCO.DATA_MOVIMENTO = :LTMVPRCO-DATA-MOVIMENTO
            AND LTMVPRCO.HORA_MOVIMENTO = :LTMVPRCO-HORA-MOVIMENTO
            AND LTMVPRCO.COD_PRODUTO = :LTMVPRCO-COD-PRODUTO
            AND LTMVPRCO.COD_EXT_ESTIP = :LTMVPRCO-COD-EXT-ESTIP
            AND LTMVPRCO.COD_COBERTURA = :LTMVPRCO-COD-COBERTURA
            AND LTMVPRCO.COD_MOVIMENTO = :LTMVPRCO-COD-MOVIMENTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT LTMVPRCO.VAL_IMP_SEGURADA
											, LTMVPRCO.VAL_TAXA_PREMIO
											FROM SEGUROS.LT_MOV_PROP_COBER LTMVPRCO
											WHERE LTMVPRCO.COD_EXT_SEGURADO = '{this.LTMVPRCO_COD_EXT_SEGURADO}'
											AND LTMVPRCO.DATA_MOVIMENTO = '{this.LTMVPRCO_DATA_MOVIMENTO}'
											AND LTMVPRCO.HORA_MOVIMENTO = '{this.LTMVPRCO_HORA_MOVIMENTO}'
											AND LTMVPRCO.COD_PRODUTO = '{this.LTMVPRCO_COD_PRODUTO}'
											AND LTMVPRCO.COD_EXT_ESTIP = '{this.LTMVPRCO_COD_EXT_ESTIP}'
											AND LTMVPRCO.COD_COBERTURA = '{this.LTMVPRCO_COD_COBERTURA}'
											AND LTMVPRCO.COD_MOVIMENTO = '{this.LTMVPRCO_COD_MOVIMENTO}'
											WITH UR";

            return query;
        }
        public string LTMVPRCO_VAL_IMP_SEGURADA { get; set; }
        public string LTMVPRCO_VAL_TAXA_PREMIO { get; set; }
        public string LTMVPRCO_COD_EXT_SEGURADO { get; set; }
        public string LTMVPRCO_DATA_MOVIMENTO { get; set; }
        public string LTMVPRCO_HORA_MOVIMENTO { get; set; }
        public string LTMVPRCO_COD_EXT_ESTIP { get; set; }
        public string LTMVPRCO_COD_COBERTURA { get; set; }
        public string LTMVPRCO_COD_MOVIMENTO { get; set; }
        public string LTMVPRCO_COD_PRODUTO { get; set; }

        public static B2061_00_SELECT_COBER_DB_SELECT_1_Query1 Execute(B2061_00_SELECT_COBER_DB_SELECT_1_Query1 b2061_00_SELECT_COBER_DB_SELECT_1_Query1)
        {
            var ths = b2061_00_SELECT_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2061_00_SELECT_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2061_00_SELECT_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTMVPRCO_VAL_IMP_SEGURADA = result[i++].Value?.ToString();
            dta.LTMVPRCO_VAL_TAXA_PREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}