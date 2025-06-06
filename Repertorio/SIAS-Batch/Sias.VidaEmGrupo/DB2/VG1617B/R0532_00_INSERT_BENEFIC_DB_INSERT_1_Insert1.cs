using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1 : QueryBasis<R0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.BENEFICIARIOS
            VALUES (:BENEFICI-NUM-APOLICE ,
            :BENEFICI-COD-SUBGRUPO ,
            :BENEFICI-NUM-CERTIFICADO ,
            :BENEFICI-DAC-CERTIFICADO ,
            :BENEFICI-NUM-BENEFICIARIO ,
            :BENEFICI-NOME-BENEFICIARIO ,
            :BENEFICI-GRAU-PARENTESCO ,
            :BENEFICI-PCT-PART-BENEFICIA ,
            :BENEFICI-DATA-INIVIGENCIA ,
            :BENEFICI-DATA-TERVIGENCIA ,
            :BENEFICI-COD-USUARIO ,
            NULL ,
            NULL ,
            NULL ,
            :BENEFICI-NUM-CPF :VIND-CPF ,
            NULL )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.BENEFICIARIOS VALUES ({FieldThreatment(this.BENEFICI_NUM_APOLICE)} , {FieldThreatment(this.BENEFICI_COD_SUBGRUPO)} , {FieldThreatment(this.BENEFICI_NUM_CERTIFICADO)} , {FieldThreatment(this.BENEFICI_DAC_CERTIFICADO)} , {FieldThreatment(this.BENEFICI_NUM_BENEFICIARIO)} , {FieldThreatment(this.BENEFICI_NOME_BENEFICIARIO)} , {FieldThreatment(this.BENEFICI_GRAU_PARENTESCO)} , {FieldThreatment(this.BENEFICI_PCT_PART_BENEFICIA)} , {FieldThreatment(this.BENEFICI_DATA_INIVIGENCIA)} , {FieldThreatment(this.BENEFICI_DATA_TERVIGENCIA)} , {FieldThreatment(this.BENEFICI_COD_USUARIO)} , NULL , NULL , NULL ,  {FieldThreatment((this.VIND_CPF?.ToInt() == -1 ? null : this.BENEFICI_NUM_CPF))} , NULL )";

            return query;
        }
        public string BENEFICI_NUM_APOLICE { get; set; }
        public string BENEFICI_COD_SUBGRUPO { get; set; }
        public string BENEFICI_NUM_CERTIFICADO { get; set; }
        public string BENEFICI_DAC_CERTIFICADO { get; set; }
        public string BENEFICI_NUM_BENEFICIARIO { get; set; }
        public string BENEFICI_NOME_BENEFICIARIO { get; set; }
        public string BENEFICI_GRAU_PARENTESCO { get; set; }
        public string BENEFICI_PCT_PART_BENEFICIA { get; set; }
        public string BENEFICI_DATA_INIVIGENCIA { get; set; }
        public string BENEFICI_DATA_TERVIGENCIA { get; set; }
        public string BENEFICI_COD_USUARIO { get; set; }
        public string BENEFICI_NUM_CPF { get; set; }
        public string VIND_CPF { get; set; }

        public static void Execute(R0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1 r0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1)
        {
            var ths = r0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0532_00_INSERT_BENEFIC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}