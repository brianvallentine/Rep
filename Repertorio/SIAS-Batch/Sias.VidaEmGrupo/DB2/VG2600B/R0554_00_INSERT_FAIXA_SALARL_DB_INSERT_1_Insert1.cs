using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1 : QueryBasis<R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.FAIXA_SALARIAL
            VALUES (:FAIXASAL-NUM-APOLICE ,
            :FAIXASAL-COD-SUBGRUPO ,
            :FAIXASAL-FAIXA ,
            :FAIXASAL-SALARIO-INICIAL ,
            :FAIXASAL-SALARIO-FINAL ,
            :FAIXASAL-TAXA-VG ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.FAIXA_SALARIAL VALUES ({FieldThreatment(this.FAIXASAL_NUM_APOLICE)} , {FieldThreatment(this.FAIXASAL_COD_SUBGRUPO)} , {FieldThreatment(this.FAIXASAL_FAIXA)} , {FieldThreatment(this.FAIXASAL_SALARIO_INICIAL)} , {FieldThreatment(this.FAIXASAL_SALARIO_FINAL)} , {FieldThreatment(this.FAIXASAL_TAXA_VG)} , NULL )";

            return query;
        }
        public string FAIXASAL_NUM_APOLICE { get; set; }
        public string FAIXASAL_COD_SUBGRUPO { get; set; }
        public string FAIXASAL_FAIXA { get; set; }
        public string FAIXASAL_SALARIO_INICIAL { get; set; }
        public string FAIXASAL_SALARIO_FINAL { get; set; }
        public string FAIXASAL_TAXA_VG { get; set; }

        public static void Execute(R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1 r0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1)
        {
            var ths = r0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0554_00_INSERT_FAIXA_SALARL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}