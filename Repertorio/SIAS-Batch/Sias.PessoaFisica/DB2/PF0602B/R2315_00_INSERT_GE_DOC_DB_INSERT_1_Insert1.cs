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
    public class R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 : QueryBasis<R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.GE_DOC_CLIENTE
            (COD_CLIENTE ,
            COD_IDENTIFICACAO ,
            NOM_ORGAO_EXP ,
            DTH_EXPEDICAO ,
            COD_UF)
            VALUES (:GEDOCCLI-COD-CLIENTE ,
            :GEDOCCLI-COD-IDENTIFICACAO,
            :GEDOCCLI-NOM-ORGAO-EXP ,
            :GEDOCCLI-DTH-EXPEDICAO ,
            :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES ({FieldThreatment(this.GEDOCCLI_COD_CLIENTE)} , {FieldThreatment(this.GEDOCCLI_COD_IDENTIFICACAO)}, {FieldThreatment(this.GEDOCCLI_NOM_ORGAO_EXP)} , {FieldThreatment(this.GEDOCCLI_DTH_EXPEDICAO)} ,  {FieldThreatment((this.VIND_UF_EXPEDIDORA?.ToInt() == -1 ? null : this.GEDOCCLI_COD_UF))})";

            return query;
        }
        public string GEDOCCLI_COD_CLIENTE { get; set; }
        public string GEDOCCLI_COD_IDENTIFICACAO { get; set; }
        public string GEDOCCLI_NOM_ORGAO_EXP { get; set; }
        public string GEDOCCLI_DTH_EXPEDICAO { get; set; }
        public string GEDOCCLI_COD_UF { get; set; }
        public string VIND_UF_EXPEDIDORA { get; set; }

        public static void Execute(R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1)
        {
            var ths = r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}