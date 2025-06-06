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
    public class R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1 : QueryBasis<R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.FAIXA_ETARIA
            VALUES (:FAIXAETA-NUM-APOLICE ,
            :FAIXAETA-COD-SUBGRUPO ,
            :FAIXAETA-FAIXA ,
            :FAIXAETA-IDADE-INICIAL ,
            :FAIXAETA-IDADE-FINAL ,
            :FAIXAETA-TAXA-VG ,
            NULL ,
            :FAIXAETA-DATA-INIVIGENCIA ,
            :FAIXAETA-DATA-TERVIGENCIA )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.FAIXA_ETARIA VALUES ({FieldThreatment(this.FAIXAETA_NUM_APOLICE)} , {FieldThreatment(this.FAIXAETA_COD_SUBGRUPO)} , {FieldThreatment(this.FAIXAETA_FAIXA)} , {FieldThreatment(this.FAIXAETA_IDADE_INICIAL)} , {FieldThreatment(this.FAIXAETA_IDADE_FINAL)} , {FieldThreatment(this.FAIXAETA_TAXA_VG)} , NULL , {FieldThreatment(this.FAIXAETA_DATA_INIVIGENCIA)} , {FieldThreatment(this.FAIXAETA_DATA_TERVIGENCIA)} )";

            return query;
        }
        public string FAIXAETA_NUM_APOLICE { get; set; }
        public string FAIXAETA_COD_SUBGRUPO { get; set; }
        public string FAIXAETA_FAIXA { get; set; }
        public string FAIXAETA_IDADE_INICIAL { get; set; }
        public string FAIXAETA_IDADE_FINAL { get; set; }
        public string FAIXAETA_TAXA_VG { get; set; }
        public string FAIXAETA_DATA_INIVIGENCIA { get; set; }
        public string FAIXAETA_DATA_TERVIGENCIA { get; set; }

        public static void Execute(R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1 r0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1)
        {
            var ths = r0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0552_00_INSERT_FAIXA_ETARIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}