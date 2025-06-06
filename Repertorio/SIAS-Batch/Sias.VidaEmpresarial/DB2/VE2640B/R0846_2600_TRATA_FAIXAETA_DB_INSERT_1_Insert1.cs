using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1 : QueryBasis<R0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.FAIXA_ETARIA
            ( NUM_APOLICE ,
            COD_SUBGRUPO ,
            FAIXA ,
            IDADE_INICIAL ,
            IDADE_FINAL ,
            TAXA_VG ,
            COD_EMPRESA ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA )
            VALUES
            ( :FAIXAETA-NUM-APOLICE ,
            :FAIXAETA-COD-SUBGRUPO ,
            :FAIXAETA-FAIXA ,
            :FAIXAETA-IDADE-INICIAL ,
            :FAIXAETA-IDADE-FINAL ,
            :FAIXAETA-TAXA-VG ,
            :FAIXAETA-COD-EMPRESA ,
            :FAIXAETA-DATA-INIVIGENCIA,
            :FAIXAETA-DATA-TERVIGENCIA )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.FAIXA_ETARIA ( NUM_APOLICE , COD_SUBGRUPO , FAIXA , IDADE_INICIAL , IDADE_FINAL , TAXA_VG , COD_EMPRESA , DATA_INIVIGENCIA , DATA_TERVIGENCIA ) VALUES ( {FieldThreatment(this.FAIXAETA_NUM_APOLICE)} , {FieldThreatment(this.FAIXAETA_COD_SUBGRUPO)} , {FieldThreatment(this.FAIXAETA_FAIXA)} , {FieldThreatment(this.FAIXAETA_IDADE_INICIAL)} , {FieldThreatment(this.FAIXAETA_IDADE_FINAL)} , {FieldThreatment(this.FAIXAETA_TAXA_VG)} , {FieldThreatment(this.FAIXAETA_COD_EMPRESA)} , {FieldThreatment(this.FAIXAETA_DATA_INIVIGENCIA)}, {FieldThreatment(this.FAIXAETA_DATA_TERVIGENCIA)} )";

            return query;
        }
        public string FAIXAETA_NUM_APOLICE { get; set; }
        public string FAIXAETA_COD_SUBGRUPO { get; set; }
        public string FAIXAETA_FAIXA { get; set; }
        public string FAIXAETA_IDADE_INICIAL { get; set; }
        public string FAIXAETA_IDADE_FINAL { get; set; }
        public string FAIXAETA_TAXA_VG { get; set; }
        public string FAIXAETA_COD_EMPRESA { get; set; }
        public string FAIXAETA_DATA_INIVIGENCIA { get; set; }
        public string FAIXAETA_DATA_TERVIGENCIA { get; set; }

        public static void Execute(R0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1 r0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1)
        {
            var ths = r0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0846_2600_TRATA_FAIXAETA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}